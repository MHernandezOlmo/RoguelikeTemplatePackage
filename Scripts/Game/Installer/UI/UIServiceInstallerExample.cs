using Core.Install.Base;
using Core.Install.Ports;
using Game.UI.Controllers;
using Game.Units.Graphics;
using Units.Ports;

namespace Game.Installer.UI
{
    public class UIServiceInstallerExample : IDependencyInstaller
    {
        public readonly ExampleUnitImagesUIService ExampleUnitImagesUIService = new();
        public readonly ExampleUnitCounterUIService ExampleUnitCounterUIService = new();
        
        public void DefineReferences(IReferencesRepository referencesLocator) { }
        public void Uninstall(IReferencesRepository referencesLocator) { }

        public void Install(IReferencesRepository referencesLocator)
        {
            var unitsSystem = referencesLocator.GetReference<IUnitsSystem>();
            
            ExampleUnitImagesUIService.SetData(unitsSystem, 
                referencesLocator.GetReference<IUnitGraphicsRepository>());
            ExampleUnitCounterUIService.SetData(unitsSystem);
        }
    }
    
}