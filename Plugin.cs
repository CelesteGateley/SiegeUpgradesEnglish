using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using BepInEx;
using BepInEx.Bootstrap;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;

namespace SiegeUpgradesEnglish;

public enum TranslationMode
{
    Auto,
    AlwaysEnglish,
    Off,
}

// PluginInfo.Version is generated at build time from thunderstore/manifest.json (see the .csproj).
[BepInPlugin(Guid, "SiegeUpgradesEnglish", PluginInfo.Version)]
[BepInDependency(TargetGuid)]
public class Plugin : BaseUnityPlugin
{
    public const string Guid = "celeste.stonewards.siegeupgrades.english";
    public const string TargetGuid = "catedralemchamas.stonewards.siegeupgrades";

    internal static ManualLogSource Log;
    private static ConfigEntry<TranslationMode> _mode;

    /// <summary>The one value checked on every translated string. Kept as a plain static bool so the hot path is trivial.</summary>
    internal static bool English;

    private Harmony _harmony;
    private Assembly _target;
    private ConfigFile _targetConfig;
    private readonly Dictionary<ConfigDefinition, ConfigDescription> _originalDescriptions = new Dictionary<ConfigDefinition, ConfigDescription>();
    private bool? _configLanguageApplied;
    private bool _localeResolved;
    private Delegate _localeChangedHandler;
    private float _nextPoll;

    private void Awake()
    {
        Log = Logger;
        _mode = Config.Bind("General", "Mode", TranslationMode.Auto,
            "Auto = English only when the game language is English. AlwaysEnglish = always translate. Off = leave SiegeUpgrades untranslated.");
        _mode.SettingChanged += (_, _) => Refresh(force: true);

        if (!Chainloader.PluginInfos.TryGetValue(TargetGuid, out var info) || info.Instance == null)
        {
            Log.LogError("SiegeUpgrades not found; nothing to translate.");
            return;
        }

        _target = info.Instance.GetType().Assembly;
        _targetConfig = info.Instance.Config;
        if (info.Metadata.Version.ToString() != "1.1.0")
        {
            Log.LogWarning($"Translations were written for SiegeUpgrades 1.1.0, found {info.Metadata.Version}. New or changed text will stay in Portuguese.");
        }

        _harmony = new Harmony(Guid);
        PatchLiterals();
        PatchDecimalFormat();

        English = _mode.Value == TranslationMode.AlwaysEnglish;
        ApplyConfigLanguage();
    }

    private void Update()
    {
        if (_target == null || _localeResolved || Time.unscaledTime < _nextPoll)
        {
            return;
        }
        _nextPoll = Time.unscaledTime + 0.5f;
        try
        {
            if (!GameLanguage.Bind())
            {
                _localeResolved = true;
                Log.LogWarning("Couldn't find the game's language settings; falling back to Mode setting only.");
                return;
            }
            if (!GameLanguage.IsReady())
            {
                return;
            }
            _localeResolved = true;
            if (_localeChangedHandler == null)
            {
                _localeChangedHandler = GameLanguage.Subscribe(this, nameof(OnLocaleChanged));
            }
            Refresh(force: false);
        }
        catch (Exception e)
        {
            _localeResolved = true; // don't spam
            Log.LogWarning("Couldn't read the game language; falling back to Mode setting only. " + (e.InnerException ?? e).Message);
        }
    }

    /// <summary>Bound to <c>LocalizationSettings.SelectedLocaleChanged</c> (an <c>Action&lt;Locale&gt;</c>), so the parameter is the Locale.</summary>
    private void OnLocaleChanged(object _) => Refresh(force: false);

    private static bool GameIsEnglish()
    {
        try
        {
            var code = GameLanguage.Code();
            return code != null && code.StartsWith("en", StringComparison.OrdinalIgnoreCase);
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Reads the game's Unity Localization settings through reflection. Unity.Localization is a Unity package
    /// that isn't on NuGet, so referencing it directly would mean the build needs a game install.
    /// </summary>
    private static class GameLanguage
    {
        private const BindingFlags Static = BindingFlags.Public | BindingFlags.Static;
        private const BindingFlags Instance = BindingFlags.Public | BindingFlags.Instance;

        private static bool _bound;
        private static PropertyInfo _hasSettings, _initializationOperation, _isDone, _selectedLocale, _identifier, _code;
        private static EventInfo _selectedLocaleChanged;

        /// <summary>Looks up the members once. False if the game doesn't have them.</summary>
        public static bool Bind()
        {
            if (_bound)
            {
                return true;
            }
            var settings = Type.GetType("UnityEngine.Localization.Settings.LocalizationSettings, Unity.Localization");
            var locale = Type.GetType("UnityEngine.Localization.Locale, Unity.Localization");
            _hasSettings = settings?.GetProperty("HasSettings", Static);
            _initializationOperation = settings?.GetProperty("InitializationOperation", Static);
            _isDone = _initializationOperation?.PropertyType.GetProperty("IsDone", Instance);
            _selectedLocale = settings?.GetProperty("SelectedLocale", Static);
            _selectedLocaleChanged = settings?.GetEvent("SelectedLocaleChanged", Static);
            _identifier = locale?.GetProperty("Identifier", Instance);
            _code = _identifier?.PropertyType.GetProperty("Code", Instance);
            _bound = _hasSettings != null && _isDone != null && _selectedLocale != null && _code != null;
            return _bound;
        }

        public static bool IsReady() =>
            (bool)_hasSettings.GetValue(null) && (bool)_isDone.GetValue(_initializationOperation.GetValue(null));

        public static string Code()
        {
            var locale = _selectedLocale.GetValue(null);
            if (locale == null)
            {
                return null;
            }
            return _code.GetValue(_identifier.GetValue(locale)) as string;
        }

        /// <summary>Subscribes <paramref name="target"/>.<paramref name="method"/>(object) to SelectedLocaleChanged. Null if the event is missing.</summary>
        public static Delegate Subscribe(object target, string method)
        {
            if (_selectedLocaleChanged == null)
            {
                return null;
            }
            var mi = target.GetType().GetMethod(method, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            var handler = Delegate.CreateDelegate(_selectedLocaleChanged.EventHandlerType, target, mi);
            _selectedLocaleChanged.AddEventHandler(null, handler);
            return handler;
        }

        public static void Unsubscribe(Delegate handler) => _selectedLocaleChanged?.RemoveEventHandler(null, handler);
    }

    private void Refresh(bool force)
    {
        bool english = _mode.Value switch
        {
            TranslationMode.AlwaysEnglish => true,
            TranslationMode.Off => false,
            _ => _localeResolved && GameIsEnglish(),
        };
        if (english == English && !force)
        {
            return;
        }
        English = english;
        Log.LogInfo($"SiegeUpgrades text: {(english ? "English" : "original (Portuguese)")}.");
        ResetCachedTexts();
        ApplyConfigLanguage();
    }

    // ---------------------------------------------------------------- string literals

    /// <summary>Called in place of every translated literal: <c>ldstr "pt"</c> becomes <c>ldstr "pt"; call T</c>.</summary>
    public static string T(string s)
    {
        if (!English)
        {
            return s;
        }
        return Translations.Literals.TryGetValue(s, out var en) ? en : s;
    }

    private void PatchLiterals()
    {
        var transpiler = new HarmonyMethod(AccessTools.Method(typeof(Plugin), nameof(Transpiler)));
        Type[] types;
        try
        {
            types = _target.GetTypes();
        }
        catch (ReflectionTypeLoadException e)
        {
            types = e.Types.Where(t => t != null).ToArray();
        }

        int patched = 0, failed = 0;
        const BindingFlags all = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
        foreach (var type in types)
        {
            // Config is handled separately (already bound by the time we run); art strings are pixel maps.
            if (type.ContainsGenericParameters || type.Name == "SiegeConfig" || type.Name == "SiegeArt")
            {
                continue;
            }
            foreach (var method in type.GetMethods(all))
            {
                if (method.IsAbstract || method.ContainsGenericParameters || !HasTranslatableLiteral(method))
                {
                    continue;
                }
                try
                {
                    _harmony.Patch(method, transpiler: transpiler);
                    patched++;
                }
                catch (Exception e)
                {
                    failed++;
                    Log.LogWarning($"Couldn't patch {type.FullName}.{method.Name}: {e.Message}");
                }
            }
        }
        Log.LogInfo($"Patched {patched} SiegeUpgrades methods" + (failed > 0 ? $" ({failed} failed)." : "."));
    }

    private static bool HasTranslatableLiteral(MethodInfo method)
    {
        try
        {
            return PatchProcessor.ReadMethodBody(method)
                .Any(kv => kv.Key == OpCodes.Ldstr && kv.Value is string s && Translations.Literals.ContainsKey(s));
        }
        catch
        {
            return false;
        }
    }

    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var t = AccessTools.Method(typeof(Plugin), nameof(T));
        foreach (var ins in instructions)
        {
            yield return ins;
            if (ins.opcode == OpCodes.Ldstr && ins.operand is string s && Translations.Literals.ContainsKey(s))
            {
                yield return new CodeInstruction(OpCodes.Call, t);
            }
        }
    }

    // ---------------------------------------------------------------- decimals: "1,5" -> "1.5" in English

    private void PatchDecimalFormat()
    {
        var dec = AccessTools.Method(_target.GetType("SiegeUpgrades.UI.Txt"), "Dec");
        if (dec == null)
        {
            Log.LogWarning("Txt.Dec not found; decimals keep the comma.");
            return;
        }
        _harmony.Patch(dec, prefix: new HarmonyMethod(AccessTools.Method(typeof(Plugin), nameof(DecPrefix))));
    }

    private static bool DecPrefix(float value, string format, ref string __result)
    {
        if (!English)
        {
            return true;
        }
        __result = value.ToString(format, CultureInfo.InvariantCulture);
        return false;
    }

    // ---------------------------------------------------------------- cached UI text

    /// <summary>The window caches built strings until the numbers in them change; clear them so a language switch shows up immediately.</summary>
    private void ResetCachedTexts()
    {
        try
        {
            var windowType = _target.GetType("SiegeUpgrades.UI.SiegeWindow");
            var cachedType = _target.GetType("SiegeUpgrades.UI.CachedText");
            if (windowType == null || cachedType == null)
            {
                return;
            }
            foreach (var window in FindObjectsByType(windowType, FindObjectsSortMode.None))
            {
                foreach (var f in windowType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public))
                {
                    if (f.FieldType == cachedType)
                    {
                        f.SetValue(window, Activator.CreateInstance(cachedType));
                    }
                    else if (f.FieldType.IsArray && f.FieldType.GetElementType() == cachedType && f.GetValue(window) is Array arr)
                    {
                        Array.Clear(arr, 0, arr.Length);
                    }
                }
            }
        }
        catch (Exception e)
        {
            Log.LogWarning("Couldn't reset cached window text: " + e.Message);
        }
    }

    // ---------------------------------------------------------------- config descriptions

    private static readonly FieldInfo DescriptionField = AccessTools.Field(typeof(ConfigEntryBase), "<Description>k__BackingField");

    private void ApplyConfigLanguage()
    {
        if (_targetConfig == null || DescriptionField == null || _configLanguageApplied == English)
        {
            return;
        }
        try
        {
            foreach (var kv in _targetConfig.ToList())
            {
                var entry = kv.Value;
                var def = kv.Key;
                if (!_originalDescriptions.TryGetValue(def, out var original))
                {
                    original = entry.Description;
                    _originalDescriptions[def] = original;
                }
                var replacement = original;
                if (English && Translations.Config.TryGetValue(def.Section + "." + def.Key, out var en))
                {
                    replacement = new ConfigDescription(en, original.AcceptableValues, original.Tags);
                }
                DescriptionField.SetValue(entry, replacement);
            }
            _targetConfig.Save();
            _configLanguageApplied = English;
        }
        catch (Exception e)
        {
            Log.LogWarning("Couldn't translate the SiegeUpgrades config descriptions: " + e.Message);
        }
    }

    private void OnDestroy()
    {
        if (_localeChangedHandler != null)
        {
            try { GameLanguage.Unsubscribe(_localeChangedHandler); } catch { }
        }
        _harmony?.UnpatchSelf();
    }
}
