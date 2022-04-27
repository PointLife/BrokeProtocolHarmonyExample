# BrokeProtocolHarmonyExample

Used https://github.com/CabbageCrow/AssemblyPublicizer/releases/download/v1.1.0/AssemblyPublicizer.zip. 

> A tool to create a copy of an assembly in which all members are public (types, methods, fields, getters and setters of properties).

This allows us to do `[HarmonyPatch(nameof(SvManager.StartServer))]` where as `SvManager.StartServer` technically is private and would not compile.
However, patching `SvManager.StartServer` does not work, because the plugin is loaded after it is run. Harmony can only patch methodes that are run in the future.

Harmony can be installed from NuGet. This is a example and in its current state should not be taken as a guide.
