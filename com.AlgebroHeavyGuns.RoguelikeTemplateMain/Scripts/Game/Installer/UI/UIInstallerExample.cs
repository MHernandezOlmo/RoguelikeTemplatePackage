using Core.Install.Base;
using Core.Install.Ports;
using Game.UI.Widgets;
using UnityEngine;

namespace Game.Installer.UI
{
    public class UIInstallerExample : MonoBehaviour, ISystemInstaller
    {
        public ExampleUnitCounterPanel UnitCounterPanel;
        public ExampleUnitImageShowcaseWidget UnitImageShowcasePanel;

        private UIControllersInstallerExample uiControllersInstaller;
        private UIServiceInstallerExample uiServiceInstaller;
        
        public void DefineReferences(IReferencesRepository referencesLocator)
        {
            uiServiceInstaller = new();
            uiControllersInstaller = new(this, uiServiceInstaller);
            uiControllersInstaller.DefineReferences(referencesLocator);
            uiServiceInstaller.DefineReferences(referencesLocator);
        }

        public void Install(IReferencesRepository referencesLocator)
        {
            uiControllersInstaller.Install(referencesLocator);
            uiServiceInstaller.Install(referencesLocator);
        }

        public void Uninstall(IReferencesRepository referencesLocator)
        {
            uiControllersInstaller.Uninstall(referencesLocator);
            uiServiceInstaller.Uninstall(referencesLocator);
        }

        public void Initialize()
        {
            uiControllersInstaller.Initialize();
        }

        public void Dispose()
        {
            uiControllersInstaller.Dispose();
        }

        public void Tick(float deltaTime)
        {
            uiControllersInstaller.Tick(deltaTime);
        }
    }
}