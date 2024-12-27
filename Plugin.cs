using BepInEx;
using BepInEx.Unity.IL2CPP;

namespace MiSideRPC;

[BepInPlugin(Constants.PluginGuid, Constants.PluginName, Constants.PluginVersion)]
public class RPCPlugin : BasePlugin
{
    public override void Load()
    {
        AddComponent<RichPresenceUpdater>();
        Log.LogInfo($"{Constants.PluginName} (v{Constants.PluginVersion}) was loaded!");
    }
}