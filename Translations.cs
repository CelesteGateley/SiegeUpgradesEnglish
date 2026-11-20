using System.Collections.Generic;

namespace SiegeUpgradesEnglish;

/// <summary>
/// Portuguese -> English tables for SiegeUpgrades 1.1.0.
/// Keys must match the original string literals exactly (including leading/trailing spaces),
/// because many sentences are glued together from fragments in the original code.
/// </summary>
internal static class Translations
{
    /// <summary>String literals used by the UI, notices and logs.</summary>
    public static readonly Dictionary<string, string> Literals = new Dictionary<string, string>
    {
        // ---- Names (SiegeTypes) ----
        ["Balista"] = "Ballista",
        ["Catapulta"] = "Catapult",
        ["da "] = "on ",                       // "Damage on Ballista Lv 3"
        ["Adicionar balista"] = "Add ballista",
        ["Adicionar trabuco"] = "Add trebuchet",
        ["Dano"] = "Damage",
        ["Velocidade de ataque"] = "Attack speed",
        ["Velocidade do projétil"] = "Projectile speed",
        ["Projéteis extras"] = "Extra projectiles",
        ["Área da explosão"] = "Explosion area",
        ["Alcance"] = "Range",
        ["Ricochete"] = "Ricochet",
        ["Congelamento"] = "Freeze",
        ["Fogo"] = "Fire",
        ["Veneno"] = "Poison",
        ["Lentidão"] = "Slow",
        ["Estilhaços"] = "Shrapnel",
        ["Virote explosivo"] = "Explosive bolt",
        ["Gelo"] = "Freeze",
        ["Explosão"] = "Explosion",

        // ---- World interaction prompt ----
        ["Melhorias da Balista"] = "Ballista Upgrades",
        ["Melhorias da Catapulta"] = "Catapult Upgrades",

        // ---- Window: header / footer ----
        ["Defesas do Muro"] = "Wall Defenses",
        ["Fechar (E / Esc)"] = "Close (E / Esc)",
        ["Aguardando o servidor..."] = "Waiting for the server...",
        ["E / Esc: fechar"] = "E / Esc: close",
        ["Cada nível da Forja dá 1 ponto · cada wave sobrevivida dá 1 escolha de efeito"] =
            "Each Forge level gives 1 point · each wave survived gives 1 effect choice",
        ["Pontos da Forja: {0} para gastar ({1} ganhos, {2} gastos). "] =
            "Forge Points: {0} to spend ({1} earned, {2} spent). ",
        ["Cada nível novo da Forja dá pontos (agora a Forja está no nível {0}). Valem para as melhorias das duas defesas."] =
            "Each new Forge level gives points (the Forge is now level {0}). They are shared by the upgrades of both defenses.",
        ["Escolhas de efeito: {0} para usar ({1} ganhas, {2} usadas). "] =
            "Effect Choices: {0} to spend ({1} earned, {2} used). ",
        ["Cada wave sobrevivida dá uma escolha ({0} waves até agora)."] =
            "Each wave survived gives one choice ({0} waves so far).",

        // ---- Window: defense sheet (left side) ----
        ["Nv "] = "Lv ",
        ["Nível = melhorias e efeitos comprados para esta defesa. Valem para as duas posições do muro, e também para uma defesa construída depois."] =
            "Level = upgrades and effects bought for this defense. They apply to both wall slots, including a defense built later.",
        ["Defesa automática"] = "Automated defense",
        ["Dano "] = "Damage ",
        ["Dano de cada disparo (com as cartas do jogo e a melhoria de Dano)"] =
            "Damage per shot (with the game's cards and the Damage upgrade)",
        ["Vel. ataque ×"] = "Atk speed ×",
        ["Velocidade de ataque comparada com a defesa normal"] = "Attack speed compared with the normal defense",
        ["Vel. projétil "] = "Proj. speed ",
        ["Velocidade do virote"] = "Bolt speed",
        ["Velocidade da pedra (cai no mesmo ponto, só chega antes)"] =
            "Rock speed (lands on the same spot, just arrives sooner)",
        ["Projéteis +"] = "Projectiles +",
        ["Projéteis extras em cada disparo"] = "Extra projectiles per shot",
        ["Área "] = "Area ",
        ["Raio da explosão da pedra"] = "Blast radius of the rock",
        ["Recarga "] = "Reload ",
        ["Tempo mínimo entre disparos (a animação de disparo também acelera quando precisa)"] =
            "Minimum time between shots (the firing animation also speeds up when needed)",
        ["Alcance "] = "Range ",
        ["Distância em que a defesa acha monstros"] = "Distance at which the defense finds enemies",
        ["Efeitos ativos"] = "Active effects",
        ["Nenhum ainda — use as escolhas de wave"] = "None yet — use your wave choices",
        ["Posições no muro"] = "Wall slots",

        // ---- Window: wall slots ----
        ["Esquerda"] = "Left",
        ["Direita"] = "Right",
        ["Vazia"] = "Empty",
        ["Posição "] = "",                     // "Posição " + side + " do muro: " + name + " construída"
        ["esquerda"] = "Left",
        ["direita"] = "Right",
        [" do muro: "] = " wall slot: ",
        [" construída"] = " built",
        ["Posição livre: as cartas 'Adicionar balista' e 'Adicionar trabuco' do fim da wave constroem aqui"] =
            "Free slot: the end-of-wave cards 'Add ballista' and 'Add trebuchet' build here",
        ["Ativa (esquerda e direita)"] = "Active (left and right)",
        ["Ativa (direita)"] = "Active (right)",
        ["Ativa (esquerda)"] = "Active (left)",
        ["Não construída — as duas posições do muro já estão ocupadas."] = "Not built — both wall slots are already taken.",
        ["Não construída — escolha a carta '"] = "Not built — pick the '",
        ["' no fim de uma wave."] = "' card at the end of a wave.",

        // ---- Window: upgrades (right side) ----
        ["Melhorias com pontos da Forja"] = "Upgrades (Forge Points)",
        ["Efeitos (1 escolha por wave)"] = "Effects (1 choice per wave)",
        ["Na Balista cada acerto sorteia os efeitos, inclusive o ricochete do virote."] =
            "On the Ballista, effects roll on every hit, including the bolt's ricochet.",
        ["Na Catapulta os efeitos valem para todos os monstros da explosão; os estilhaços saem uma vez por pedra."] =
            "On the Catapult, effects roll for every enemy caught in the blast; shrapnel rolls once per rock.",
        ["ponto"] = "point",
        ["pontos"] = "points",
        ["escolha"] = "choice",
        ["escolhas"] = "choices",
        [" para usar"] = " available",
        ["{0} {1} para usar"] = "{0} {1} available",
        ["Nv {0}/{1}"] = "Lv {0}/{1}",
        ["pontos da Forja"] = "Forge Points",
        ["escolhas de efeito"] = "Effect Choices",
        ["Chance {0}% » {1}%"] = "Chance {0}% » {1}%",
        ["Chance {0}%"] = "Chance {0}%",
        ["MÁX"] = "MAX",
        ["Faltam {0} {1}"] = "Need {0} more {1}",
        ["Comprando..."] = "Buying...",
        ["Comprar o próximo nível"] = "Buy the next level",

        // ---- Tooltips: stats ----
        ["Nível máximo."] = "Max level.",
        ["Próximo nível: 1 ponto da Forja."] = "Next level: 1 Forge Point.",
        ["Próximo nível: {0} pontos da Forja."] = "Next level: {0} Forge Points.",
        ["% de dano por nível, por cima das cartas do jogo (ex.: Balista Melhorada)."] =
            "% damage per level, on top of the game's cards (e.g. Improved Ballista).",
        ["% de velocidade de ataque por nível: recarga e mira mais curtas e animação de disparo mais rápida."] =
            "% attack speed per level: shorter reload and aim time, and a faster firing animation.",
        ["% por nível: o virote chega antes no alvo."] = "% per level: the bolt reaches the target sooner.",
        ["% por nível: a pedra chega antes e cai no mesmo ponto (erra menos monstros andando)."] =
            "% per level: the rock arrives sooner and lands on the same spot (misses fewer moving enemies).",
        ["+1 virote por disparo por nível, num leque na horizontal, com "] =
            "+1 bolt per shot per level, in a horizontal fan, dealing ",
        ["+1 pedra por disparo por nível, em outros monstros no alcance (ou em volta do alvo), com "] =
            "+1 rock per shot per level, at other enemies in range (or around the target), dealing ",
        ["% do dano."] = "% damage.",
        ["% no raio da explosão por nível."] = "% blast radius per level.",
        ["% de alcance por nível: a defesa acha e atira em monstros mais longe."] =
            "% range per level: the defense finds and shoots enemies further away.",

        // ---- Tooltips: effects ----
        ["O virote pula para o monstro mais perto até "] = "The bolt jumps to the nearest enemy within ",
        [" m com "] = " m, dealing ",
        ["A pedra pula para o monstro mais perto até "] = "The rock bounces to the nearest enemy within ",
        [" m e explode de novo com "] = " m and explodes again, dealing ",
        ["Congela o monstro por "] = "Freezes the enemy for ",
        [" s (efeito de gelo do jogo; metade em elites e chefes)."] = " s (the game's freeze effect; half on elites and bosses).",
        ["Queima por "] = "Burns for ",
        [" s: "] = " s: ",
        ["% do dano do acerto a cada segundo (fogo do jogo)."] = "% of the hit damage every second (the game's fire).",
        ["Envenena por "] = "Poisons for ",
        ["% do dano do acerto a cada segundo (veneno do jogo)."] = "% of the hit damage every second (the game's poison).",
        ["Deixa o monstro "] = "Makes the enemy ",
        ["% mais lento por "] = "% slower for ",
        [" s (metade do tempo em elites e chefes)."] = " s (half as long on elites and bosses).",
        ["O acerto explode (bola de fogo do jogo) com "] = "The hit explodes (the game's fireball), dealing ",
        ["% do dano num raio de "] = "% damage in a radius of ",
        ["{0} estilhaços caem em volta da explosão, cada um explodindo com {1}% do dano (raio {2} m)."] =
            "{0} shrapnel rocks land around the blast, each exploding for {1}% damage (radius {2} m).",
        ["{0} Chance: +{1}% por nível (agora {2}%)."] = "{0} Chance: +{1}% per level (now {2}%).",

        // ---- On-screen notices (built by the host) ----
        ["Forja nível {0}: +{1} {2} da Forja para as Defesas do Muro "] = "Forge level {0}: +{1} Forge {2} for the Wall Defenses ",
        ["({0} para gastar)"] = "({0} to spend)",
        ["Wave {0} sobrevivida: +{1} {2} de efeito para as Defesas do Muro "] = "Wave {0} survived: +{1} effect {2} for the Wall Defenses ",
        ["({0} para usar)"] = "({0} to spend)",
        ["As Defesas do Muro só podem ser melhoradas durante a partida."] = "The Wall Defenses can only be upgraded during a run.",
        [" já está no máximo."] = " is already maxed.",
        ["Faltam {0} pontos da Forja."] = "Need {0} more Forge Points.",
        ["{0}: {1} {2} Nv {3}"] = "{0}: {1} {2} Lv {3}",
        [" não existe "] = " isn't available ",
        ["Faltam {0} escolhas de efeito (ganhe sobrevivendo às waves)."] = "Need {0} more Effect Choices (earn them by surviving waves).",
        ["Jogador"] = "Player",
        ["O host usa outra versão do SiegeUpgrades (a sua: v1.1.0). A janela das defesas fica desligada."] =
            "The host uses a different version of SiegeUpgrades (yours: v1.1.0). The defense window is disabled.",
        ["Um jogador tem outra versão do SiegeUpgrades (v"] = "A player has a different version of SiegeUpgrades (v",
        ["). Atualizem o mod."] = "). Please update the mod.",

        // ---- Log messages ----
        ["SiegeUpgrades: {0} v{1} carregado (protocolo {2})."] = "SiegeUpgrades: {0} v{1} loaded (protocol {2}).",
        ["{0}: caixa de interação {1} (centro {2}), {3} modelos."] = "{0}: interaction box {1} (center {2}), {3} models.",
        [": modelos sem leitura; destaque por cor em vez do contorno."] = ": models not readable; using a color highlight instead of the outline.",
        ["SiegeUpgrades: contorno da defesa indisponível: "] = "SiegeUpgrades: defense outline unavailable: ",
        ["SiegeUpgrades: erro ao preparar as defesas: "] = "SiegeUpgrades: error preparing the defenses: ",
        ["interação preparada em "] = "interaction set up on ",
        ["SiegeUpgrades: erro na mira alternativa: "] = "SiegeUpgrades: error in the fallback aim: ",
        ["SiegeUpgrades: não deu para escalar a explosão: "] = "SiegeUpgrades: couldn't scale the explosion: ",
        ["SiegeUpgrades: input preso em GeneralMenu depois de um menu do jogo; voltando para o jogo."] =
            "SiegeUpgrades: input stuck in GeneralMenu after a game menu; returning to gameplay.",
        ["SiegeUpgrades: não consegui ajustar o menu do jogo: "] = "SiegeUpgrades: couldn't adjust the game menu: ",
        ["janela das defesas"] = "defense window",
        ["fonte do jogo"] = "game font",
        ["SiegeUpgrades: erro na interface ("] = "SiegeUpgrades: UI error (",
        ["SiegeUpgrades: não deu para tocar o som da interface: "] = "SiegeUpgrades: couldn't play the UI sound: ",
        ["SiegeUpgrades: erro no disparo melhorado: "] = "SiegeUpgrades: error in the upgraded shot: ",
        ["{0} disparou: dano {1:0.#}, velocidade {2:0.#} m/s, extras {3}."] = "{0} fired: damage {1:0.#}, speed {2:0.#} m/s, extras {3}.",
        ["SiegeUpgrades: partida nova ({0} balistas, {1} catapultas). "] = "SiegeUpgrades: new run ({0} ballistas, {1} catapults). ",
        ["Pontos da Forja {0}, escolhas de efeito {1}."] = "Forge Points {0}, Effect Choices {1}.",
        ["SiegeUpgrades: Forja nível {0} (+{1} pontos, {2} disponíveis)."] = "SiegeUpgrades: Forge level {0} (+{1} points, {2} available).",
        ["SiegeUpgrades: wave {0} sobrevivida (+{1} escolhas, {2} disponíveis)."] = "SiegeUpgrades: wave {0} survived (+{1} choices, {2} available).",
        ["SiegeUpgrades: {0} comprou {1} Nv {2} para a {3} ({4} pontos; {5} sobrando)."] =
            "SiegeUpgrades: {0} bought {1} Lv {2} for the {3} ({4} points; {5} left).",
        ["SiegeUpgrades: {0} comprou o efeito {1} Nv {2} para a {3} ({4} escolhas; {5} sobrando)."] =
            "SiegeUpgrades: {0} bought effect {1} Lv {2} for the {3} ({4} choices; {5} left).",
        ["SiegeUpgrades: o host não confirmou o protocolo (outra versão do mod). A janela das defesas fica desligada."] =
            "SiegeUpgrades: the host didn't confirm the protocol (different mod version). The defense window is disabled.",
        ["SiegeUpgrades: erro nos efeitos no acerto: "] = "SiegeUpgrades: error in on-hit effects: ",
        ["{0}: {1} em {2} ({3:0.#} s, valor {4:0.##})."] = "{0}: {1} on {2} ({3:0.#} s, value {4:0.##}).",
        ["{0}: ricochete para {1} ({2:0.#} de dano)."] = "{0}: ricochet to {1} ({2:0.#} damage).",
        ["Balista: virote explosivo ({0:0.#} de dano, raio {1:0.#} m)."] = "Ballista: explosive bolt ({0:0.#} damage, radius {1:0.#} m).",
        ["Catapulta: {0} estilhaços ({1:0.#} de dano cada, raio {2:0.#} m)."] = "Catapult: {0} shrapnel ({1:0.#} damage each, radius {2:0.#} m).",
        ["{0}: recarga {1:0.##} s, mira {2:0.##} s, projétil {3:0.#} m/s, "] = "{0}: reload {1:0.##} s, aim {2:0.##} s, projectile {3:0.#} m/s, ",
        ["alcance {0:0.#} m, "] = "range {0:0.#} m, ",
        ["explosão {0:0.#} m, animador {1}."] = "explosion {0:0.#} m, animator {1}.",
        ["nenhum"] = "none",
        ["{0}: ciclo das animações {1:0.###} s (recarga original {2:0.##} s)."] = "{0}: animation cycle {1:0.###} s (original reload {2:0.##} s).",
        ["SiegeUpgrades: mensagem "] = "SiegeUpgrades: message ",
        [" com formato diferente (outra versão do mod?), ignorada: "] = " has a different format (different mod version?), ignored: ",
        ["SiegeUpgrades: conexão {0} usa outra versão do mod (v{1}, protocolo {2}; "] = "SiegeUpgrades: connection {0} uses a different mod version (v{1}, protocol {2}; ",
        ["este host: v{0}, protocolo {1}). A janela das defesas fica desligada para esse jogador."] =
            "this host: v{0}, protocol {1}). The defense window is disabled for that player.",
        ["SiegeUpgrades: conexão {0} tem o mod (v{1}, protocolo {2})."] = "SiegeUpgrades: connection {0} has the mod (v{1}, protocol {2}).",
        ["SiegeUpgrades: erro no hello de um jogador: "] = "SiegeUpgrades: error in a player's hello: ",
        ["SiegeUpgrades: erro ao mostrar aviso: "] = "SiegeUpgrades: error showing a notice: ",
        ["SiegeUpgrades: o host confirmou o protocolo {0}."] = "SiegeUpgrades: the host confirmed protocol {0}.",
        ["SiegeUpgrades: o id {0} da mensagem {1} já tinha handler em {2} (colisão com outro mod?)."] =
            "SiegeUpgrades: id {0} of message {1} already had a handler on {2} (collision with another mod?).",
        ["SiegeUpgrades: erro ao ler o estado: "] = "SiegeUpgrades: error reading the state: ",
        ["SiegeUpgrades: erro na compra: "] = "SiegeUpgrades: error in purchase: ",
        ["SiegeUpgrades: falha ao registrar handlers do cliente: "] = "SiegeUpgrades: failed to register client handlers: ",
        ["SiegeUpgrades: falha ao registrar handlers do servidor: "] = "SiegeUpgrades: failed to register server handlers: ",
    };

    private static readonly Dictionary<string, string> StatLabels = new Dictionary<string, string>
    {
        ["Damage"] = "Damage",
        ["AttackSpeed"] = "Attack speed",
        ["ProjectileSpeed"] = "Projectile speed",
        ["ExtraProjectiles"] = "Extra projectiles",
        ["ExplosionArea"] = "Explosion area",
        ["Range"] = "Range",
    };

    private static readonly Dictionary<string, string> EffectLabels = new Dictionary<string, string>
    {
        ["Ricochet"] = "Ricochet",
        ["Freeze"] = "Freeze",
        ["Burn"] = "Fire",
        ["Poison"] = "Poison",
        ["Slow"] = "Slow",
        ["Explosion"] = "Explosive bolt / Shrapnel",
    };

    /// <summary>English config descriptions, keyed by "Section.Key".</summary>
    public static readonly Dictionary<string, string> Config = BuildConfig();

    private static Dictionary<string, string> BuildConfig()
    {
        var c = new Dictionary<string, string>
        {
            ["General.Enabled"] = "Turns the mod on/off. On the host it disables the upgrades (defenses go back to normal); on a client it disables the window.",
            ["General.ShowNotices"] = "Shows on-screen notices (Forge Point earned, Effect Choice earned, purchases). Visual only; each player chooses.",
            ["Currencies.ForgePointsPerLevel"] = "Forge Points earned for each new Forge level in the run (the Forge starts at level 1 = 0 points).",
            ["Currencies.EffectChoicesPerWave"] = "Effect Choices earned for each wave survived (completed).",
            ["Interaction.InteractDistance"] = "Maximum distance (m) to aim at a built defense and press E. The game uses 5 m for normal objects; the defenses sit high on the wall, so the default is larger.",
            ["Interaction.LookAtFallback"] = "If the game's crosshair doesn't pick up the defense (another object in front), pressing E while looking at it also opens the window when the crosshair is on nothing.",
            ["Interaction.Outline"] = "Green outline (same as the game's) on the defense when the crosshair is on it.",

            ["Damage.PercentPerLevel"] = "Damage: Extra damage per level (%). Multiplies the defense's damage on top of the game's cards (e.g. Improved Ballista).",
            ["AttackSpeed.PercentPerLevel"] = "Attack speed: Extra attack speed per level (%): divides reload and aim time and speeds up the firing animation when needed.",
            ["AttackSpeed.MaxAnimatorSpeed"] = "Cap on how much the attack animation can speed up (1 = never speeds up).",
            ["ProjectileSpeed.PercentPerLevel"] = "Projectile speed: Extra projectile speed per level (%). The Catapult rock still lands on the same spot, it just arrives sooner.",
            ["ExtraProjectiles.MaxLevel"] = "Extra projectiles: max level (0 = off). Each level gives +1 projectile per shot (Ballista: horizontal fan; Catapult: rocks on other enemies or around the target).",
            ["ExtraProjectiles.Costs"] = "Forge Points for each level, comma-separated (if values are missing, the last one repeats).",
            ["ExtraProjectiles.DamagePercent"] = "Damage of each extra projectile (% of the shot's damage).",
            ["ExtraProjectiles.BallistaSpreadDegrees"] = "Spread (degrees) between the bolts in the Ballista's fan.",
            ["ExtraProjectiles.CatapultScatterRadius"] = "With no other enemies in range, the extra rocks land around the target up to this distance (m).",
            ["ExplosionArea.PercentPerLevel"] = "Explosion area: Extra Catapult blast radius per level (%).",
            ["ExplosionArea.ScaleExplosionVfx"] = "Scales up the explosion visual along with the area (only for players with the mod; others see the normal size).",
            ["Range.PercentPerLevel"] = "Range: Extra range per level (%): the defense finds and shoots enemies further away (by default the Ballista has 50 m and the Catapult 100 m).",

            ["Ricochet.DamagePercent"] = "Ricochet: Ricochet damage (% of the shot's damage).",
            ["Ricochet.Range"] = "Ricochet: Range (m) to find the next enemy.",
            ["Freeze.Seconds"] = "Freeze: Seconds frozen (the player's freeze uses 5 s; shorter here so it doesn't stall the whole wave).",
            ["Burn.DamagePercentPerSecond"] = "Fire: Damage per second (% of the hit damage; the game uses 10%).",
            ["Burn.Seconds"] = "Fire: Seconds burning (the game uses 10 s).",
            ["Poison.DamagePercentPerSecond"] = "Poison: Damage per second (% of the hit damage; the game uses 10%).",
            ["Poison.Seconds"] = "Poison: Seconds poisoned (the game uses 10 s).",
            ["Slow.SlowPercent"] = "Slow: How much slower (%; the game uses 50%).",
            ["Slow.Seconds"] = "Slow: Seconds slowed (the game uses 10 s).",
            ["Explosion.DamagePercent"] = "Explosive bolt / Shrapnel: Explosion damage (% of the hit damage).",
            ["Explosion.Radius"] = "Explosive bolt / Shrapnel: Radius (m) of the explosion (Ballista) and of each shrapnel rock (Catapult).",
            ["Explosion.ShrapnelCount"] = "Catapult: how many shrapnel rocks come out of the explosion (each explodes with the damage and radius above).",

            ["Effects.EliteBossDurationMultiplier"] = "Freeze and slow on elites and bosses last this fraction as long (0.5 = half).",
            ["Debug.StartForgePoints"] = "Testing: extra Forge Points at the start of each run.",
            ["Debug.StartEffectChoices"] = "Testing: extra Effect Choices at the start of each run.",
            ["Debug.VerboseLog"] = "Logs every upgraded shot, applied effect and purchase.",
        };

        foreach (var kv in StatLabels)
        {
            if (kv.Key != "ExtraProjectiles")
            {
                c[kv.Key + ".MaxLevel"] = kv.Value + ": max level (0 = off).";
                c[kv.Key + ".Cost"] = kv.Value + ": Forge Points per level.";
            }
        }

        foreach (var kv in EffectLabels)
        {
            c[kv.Key + ".ChancePerLevel"] = kv.Value + ": chance per level (%) on each hit.";
            c[kv.Key + ".MaxLevel"] = kv.Value + ": max level (0 = off).";
            c[kv.Key + ".Cost"] = kv.Value + ": Effect Choices per level.";
        }

        return c;
    }
}
