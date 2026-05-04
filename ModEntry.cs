using HarmonyLib;
using StardewModdingAPI;

namespace GMCMModNameI18n;

internal sealed class ModEntry : Mod
{
    public override void Entry(IModHelper helper)
    {
        ModConfigPatch.Translations = helper.Translation;

        var modConfigType = AccessTools.TypeByName("GenericModConfigMenu.Framework.ModConfig");
        if (modConfigType is null)
        {
            this.Monitor.Log("GMCM ModConfig type not found, skipping patch.", LogLevel.Warn);
            return;
        }

        var original = AccessTools.PropertyGetter(modConfigType, "ModName");
        if (original is null)
        {
            this.Monitor.Log("GMCM ModConfig.ModName getter not found, skipping patch.", LogLevel.Warn);
            return;
        }

        var prefix = AccessTools.Method(typeof(ModConfigPatch), nameof(ModConfigPatch.ModName_Prefix));
        var harmony = new Harmony(this.ModManifest.UniqueID);
        harmony.Patch(original, prefix: new HarmonyMethod(prefix));

        this.Monitor.Log("GMCM Mod Name I18n patch applied.", LogLevel.Info);
    }
}
