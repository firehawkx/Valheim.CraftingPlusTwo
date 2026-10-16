using System;
using BepInEx;
using HarmonyLib;

namespace CraftingPlusTwo
{
    [BepInPlugin("CraftingPlusTwo", "Crafting Plus Two", "1.1.0")]
    [BepInProcess("valheim.exe")]
    public class CraftingPlusTwoMod : BaseUnityPlugin
    {
        // Station names as serialized in the 1.0 prefabs (CraftingStation.m_name).
        private static readonly string[] TargetStations =
        {
            "$piece_blackforge",
            "$piece_magetable",
        };

        // Since 1.0 a station's level is 1 + the extension pieces attached to it, so a fresh
        // Black Forge or Galdr Table starts at 1 instead of the old level 3. This bonus puts
        // the 1.0 curve back where the pre-1.0 game had it: 3 when built, rising with every
        // extension you attach. A fully extended Galdr Table reaches 7 and a fully extended
        // Black Forge 8, which is what makes the final quality-4 upgrade craftable at all.
        private const int LevelBonus = 2;

        private void Awake()
        {
            new Harmony("CraftingPlusTwo").PatchAll();
            Logger.LogInfo($"Successfully patched Galdr Table/Black Forge workaround! "
                + $"Adding {LevelBonus} levels to both (a fresh one reads 3, a fully extended one 7).");
        }

        [HarmonyPatch(typeof(CraftingStation), nameof(CraftingStation.GetLevel))]
        internal class StationLevel_Patch
        {
            [HarmonyPostfix]
            static void Postfix(ref int __result, CraftingStation __instance)
            {
                if (__instance == null)
                {
                    return;
                }

                if (Array.IndexOf(TargetStations, __instance.m_name) >= 0)
                {
                    __result += LevelBonus;
                }
            }
        }
    }
}
