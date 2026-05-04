using System.Reflection;
using HarmonyLib;
using StardewModdingAPI;

namespace GMCMModNameI18n;

internal static class ModConfigPatch
{
    public static ITranslationHelper? Translations { get; set; }

    /// <summary>Prefix for <c>ModConfig.ModName</c> getter.</summary>
    internal static bool ModName_Prefix(object __instance, ref string __result)
    {
        if (Translations is null)
            return true;

        var modManifest = __instance.GetType().GetProperty("ModManifest")?.GetValue(__instance) as IManifest;
        if (modManifest is null)
            return true;

        string key = $"gmcmodnamei18n.{modManifest.UniqueID}";
        Translation translation = Translations.Get(key);
        if (translation.HasValue())
        {
            __result = translation.ToString();
            return false;
        }

        return true;
    }
}
