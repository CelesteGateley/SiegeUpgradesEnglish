# SiegeUpgradesEnglish

A BepInEx 5 plugin that translates **SiegeUpgrades 1.1.0** for Stonewards into English, without
touching `SiegeUpgrades.dll`.

> **This is an unofficial translation.** SiegeUpgrades is made by **CatedralEmChamas**, and all
> credit for the mod belongs to them. SiegeUpgradesEnglish contains no SiegeUpgrades code, only the
> English text. Please don't report problems with the translation to the SiegeUpgrades author.
>
> The icon is based on the SiegeUpgrades icon by CatedralEmChamas, with an "EN" badge added.

## Install

Install with a Thunderstore mod manager (Gale or r2modman). This also installs BepInExPack and
SiegeUpgrades. Launch the game through the mod manager. Starting it from Steam runs it without
mods.

## What it translates

When the game is set to English, SiegeUpgrades shows English. In any other language it keeps its
original Portuguese text.

- **The upgrade window:** every label, tooltip, button, tab and stat line.
- **The prompt** shown when looking at a ballista or catapult ("Ballista Upgrades").
- **On-screen notices and log messages.**
- **Number format:** decimals show as `1.5` instead of `1,5`.
- **Config descriptions:** the comments in `catedralemchamas.stonewards.siegeupgrades.cfg`, which
  also appear in your mod manager's config editor.

Changing the game's language updates the window straight away, without a restart.

## Settings

`BepInEx/config/celeste.stonewards.siegeupgrades.english.cfg`:

| Setting | Values |
|---|---|
| `Mode` | `Auto` (default): follow the game's language. `AlwaysEnglish`: always translate. `Off`: leave SiegeUpgrades untranslated. |

## Limitations

- **Multiplayer notices:** when you join someone else's game, the host's computer writes some
  notices (such as "Forge level 5: +1 point") and sends them to you. Those stay in the host's
  language unless the host also has this mod and their game is set to English.
- **SiegeUpgrades updates:** the translations match SiegeUpgrades 1.1.0. New or reworded text in a
  later version stays Portuguese until it's added here, and the log warns about the version
  mismatch.
- SiegeUpgrades' own startup log line stays Portuguese, because it's written before this mod loads.

## How it works

At startup the plugin finds every SiegeUpgrades method that loads one of the Portuguese strings in
`Translations.cs`, and uses a Harmony transpiler to pass that string through a lookup. When English
is off, the lookup returns the original string. It also patches the decimal formatter, clears the
window's cached text when the language changes, and swaps the config entry descriptions.

All the English text is in `Translations.cs`. Its keys must match the original literals exactly,
including leading and trailing spaces, because SiegeUpgrades builds many sentences from fragments.

On a successful load, `LogOutput.log` shows `Patched N SiegeUpgrades methods.` and, once the main
menu loads, `SiegeUpgrades text: English.`

## Build

Requires the .NET SDK. The build references `BepInEx.dll` and `0Harmony.dll` from a BepInEx 5 `core`
folder, set by the `BepInExCore` property in `Directory.Build.props`. By default it points at Gale's
Default profile for Stonewards (`%APPDATA%\com.kesomannen.gale\stonewards\profiles\Default\BepInEx\core`).
The Unity assemblies come from the `UnityEngine.Modules` package on `nuget.bepinex.dev`, so a game
install isn't needed. To override a property, pass `-p:<Name>=<value>` to `dotnet build`, or set it in
a `Directory.Build.props.user` file next to it. Git ignores that file.

```sh
dotnet build
```

Each local build is also copied to `<profile>/BepInEx/plugins/SiegeUpgradesEnglish/`. If Gale has the
Thunderstore release installed too, BepInEx finds two copies of the plugin, so set
`DeployToProfile` to `false` (or disable the Thunderstore one) while developing.

The version comes from `version_number` in `thunderstore/manifest.json`. It's used for the assembly,
the `[BepInPlugin]` attribute and the package.

To build the Thunderstore zip, run `pwsh ./package.ps1`. It needs `thunderstore/icon.png` (256x256)
and writes `dist/SiegeUpgradesEnglish-<version>.zip`.

## Releases

GitHub Actions (`.github/workflows/build.yml`) builds the package on every push and pull request,
and uploads it as a workflow artifact. A push to `main` also creates a GitHub release `v<version>`
with the zip attached, if that version has no release yet. To release, bump `version_number` in
`thunderstore/manifest.json`, add a matching `## <version>` section to `CHANGELOG.md` (it becomes
the release notes), and push.

When a new release is created, a second job publishes the zip to Thunderstore with `tcli`, using
`thunderstore/thunderstore.toml` for the team, community and categories. It needs a
`THUNDERSTORE_TOKEN` repo secret (a service-account token from your Thunderstore team) and runs in
the `thunderstore` environment, which can require your approval first.

## License

MIT. See `LICENSE`.
