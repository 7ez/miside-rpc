using BepInEx;
using BepInEx.Unity.IL2CPP;

namespace MiSideRPC
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class RPCPlugin : BasePlugin
    {
        public override void Load()
        {
            AddComponent<RichPresenceHandler>();
            Log.LogInfo($"{PluginInfo.PLUGIN_NAME} (v{PluginInfo.PLUGIN_VERSION}) was loaded!");
        }
    }
}
