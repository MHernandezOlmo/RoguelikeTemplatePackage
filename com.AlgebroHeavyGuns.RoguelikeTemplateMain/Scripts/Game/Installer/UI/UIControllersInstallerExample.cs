using Core.Install.Base;
using Core.Install.Ports;
using Game.UI;
using Game.UI.Controllers;

namespace Game.Installer.UI
{
    public class UIControllersInstallerExample : ISystemInstaller
    {
        private ExampleUnitCounterController unitCounterController;
        private ExampleUnitImageShowcaseController unitImageShowcaseController;
        
        private readonly UIControllersReferences uiControllersReferences = new();
        private readonly UIInstallerExample uiSceneReferences;
        private readonly UIServiceInstallerExample uiServiceInstallerExampleExample;
        
        public UIControllersInstallerExample(UIInstallerExample uiInstaller, UIServiceInstallerExample serviceInstallerExample)
        {
            uiSceneReferences = uiInstaller;
            uiServiceInstallerExampleExample = serviceInstallerExample;
        }

        public void DefineReferences(IReferencesRepository referencesLocator)
        {
            referencesLocator.AddReference<IUIControllerReferences>(uiControllersReferences);
            
            unitCounterController = new ExampleUnitCounterController(uiSceneReferences.UnitCounterPanel, uiServiceInstallerExampleExample.ExampleUnitCounterUIService);
            unitImageShowcaseController = new ExampleUnitImageShowcaseController(uiSceneReferences.UnitImageShowcasePanel, uiServiceInstallerExampleExample.ExampleUnitImagesUIService);
            
            uiControllersReferences.AddReference(unitCounterController);
            uiControllersReferences.AddReference(unitImageShowcaseController);
        }

        public void Install(IReferencesRepository referencesLocator) { }

        public void Uninstall(IReferencesRepository referencesLocator)
        {
            referencesLocator.RemoveReference<IUIControllerReferences>();

            uiControllersReferences.Clear();
        }

        public void Initialize()
        {
            unitCounterController.Initialize();
            unitImageShowcaseController.Initialize();
        }

        public void Dispose()
        {
            unitCounterController.Dispose();
            unitImageShowcaseController.Dispose();
        }

        public void Tick(float deltaTime)
        {

        }
    }
}