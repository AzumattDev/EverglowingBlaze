using System.Reflection;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace EverglowingBlaze
{
    [BepInPlugin(ModGUID, ModName, ModVersion)]
    public class EverglowingBlazePlugin : BaseUnityPlugin
    {
        internal const string ModName = "EverglowingBlaze";
        internal const string ModVersion = "1.0.1";
        internal const string Author = "Azumatt";
        private const string ModGUID = Author + "." + ModName;
        private readonly Harmony _harmony = new(ModGUID);

        public void Awake()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            _harmony.PatchAll(assembly);
        }
    }

    [HarmonyPatch(typeof(Fireplace), nameof(Fireplace.CheckWet))]
    static class FireplaceCheckWetPatch
    {
        static bool Prefix(Fireplace __instance)
        {
            __instance.m_wet = false;
            return false;
        }
    }
}