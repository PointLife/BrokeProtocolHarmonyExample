using BPCoreLib.Interfaces;
using BPCoreLib.Util;
using BrokeProtocol.API;
using HarmonyLib;
using System.Reflection;

namespace BrokeProtocolHarmonyExample
{

    public class Core : Plugin
    {
        public static Core Instance { get; internal set; }
        public ILogger Logger { get; } = new Logger();

        public Harmony Harmony { get; set; } = new Harmony("com.pointlife.harmonytest");

        public Core()
        {
            Instance = this;
            Info = new PluginInfo("HarmonyExample", "harmonyexample")
            {
                Description = "Harmony Example Plugin"
            };

            var assembly = Assembly.GetExecutingAssembly();
            Harmony.PatchAll(assembly);

        }
    }
}
