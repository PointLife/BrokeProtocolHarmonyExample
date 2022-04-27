using BrokeProtocol.Managers;
using HarmonyLib;

namespace BrokeProtocolHarmonyExample.Patches
{
    [HarmonyPatch(typeof(SvManager))]
    [HarmonyPatch(nameof(SvManager.StartServer))]
    public static class Patch
    {
        public static void Prefix()
        {
            Core.Instance.Logger.LogWarning("----------------------------------------------------------------------");
            Core.Instance.Logger.LogWarning("Harmony Injection working!");
            Core.Instance.Logger.LogWarning("Harmony Injection SvManager.StartServer Prefix!");
            Core.Instance.Logger.LogWarning("----------------------------------------------------------------------");
        }

        [HarmonyPostfix]    // Due to the name not beeing exactly Postfix, we need to specify it
        public static void PostfixYeah()
        {
            Core.Instance.Logger.LogWarning("----------------------------------------------------------------------");
            Core.Instance.Logger.LogWarning("Harmony Injection SvManager.StartServer Postfix!");
            Core.Instance.Logger.LogWarning("----------------------------------------------------------------------");
        }
    }
}
