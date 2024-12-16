using IPA;
using IPA.Loader;
using SiraUtil.Zenject;
using IPALogger = IPA.Logging.Logger;

namespace NoMoreThunder;

[Plugin(RuntimeOptions.SingleStartInit), NoEnableDisable]
internal class Plugin
{
    internal static IPALogger Log { get; private set; }
        
    [Init]
    public Plugin(IPALogger ipaLogger, PluginMetadata pluginMetadata, Zenjector zenjector)
    {
        Log = ipaLogger;
            
        zenjector.UseLogger(Log);
        zenjector.Install(Location.Menu, container =>
        {
            container.BindInterfacesTo<LightningManager>().AsSingle();
        });
            
        Log.Info($"{pluginMetadata.Name} {pluginMetadata.HVersion} initialized.");
    }
}