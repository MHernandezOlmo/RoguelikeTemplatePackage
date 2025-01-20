using Core.Install;
using Core.Install.Base;
using Core.Save.Ports;
using Entities.Ports;
using Game.Entities;
using Game.Installer.Modules;
using Game.Installer.UI;
using Units.Ports;
using UnityEngine;

namespace Game.Installer
{
    public class ContextSceneInstallerExample : ContextInstaller
    {
        [SerializeField] private UIInstallerExample uiInstallerExample;
        [SerializeField] private GameRepositories gameRepositories;

        private readonly GameModulesInstaller modulesInstaller = new();
        private readonly GameServicesInstaller servicesInstaller = new();
        
        protected override void DefineReferences()
        {
            Debug.Log("[EXAMPLE] - Defining references...");
            modulesInstaller.DefineReferences(ReferencesLocator.Instance);
            servicesInstaller.DefineReferences(ReferencesLocator.Instance);
            gameRepositories.DefineReferences(ReferencesLocator.Instance);
            uiInstallerExample.DefineReferences(ReferencesLocator.Instance);
        }

        protected override void Install()
        {
            Debug.Log("[EXAMPLE] - Installing references...");
            modulesInstaller.Install(ReferencesLocator.Instance);
            servicesInstaller.Install(ReferencesLocator.Instance);
            uiInstallerExample.Install(ReferencesLocator.Instance);
        }

        protected override void Uninstall()
        {
            Debug.Log("[EXAMPLE] - Uninstalling references...");
            modulesInstaller.Uninstall(ReferencesLocator.Instance);
            servicesInstaller.Uninstall(ReferencesLocator.Instance);
            gameRepositories.Unistall(ReferencesLocator.Instance);
            uiInstallerExample.Uninstall(ReferencesLocator.Instance);
        }

        protected override void Initialize()
        {
            Debug.Log("[EXAMPLE] - Initiating systems...");
            modulesInstaller.Initialize();
            uiInstallerExample.Initialize();
        }

        protected override void Dispose()
        {
            Debug.Log("[EXAMPLE] - Disposing systems...");
            modulesInstaller.Dispose();
            uiInstallerExample.Dispose();
        }

        protected override void Tick(float deltaTime)
        {
            modulesInstaller.Tick(deltaTime);
            uiInstallerExample.Tick(deltaTime);
        }

        protected override void PreStart()
        {
            var loadService = ReferencesLocator.Instance.GetReference<ILoadService>();
            loadService.Load();
        }

        protected override void StartSceneExecution()
        {
            Debug.Log("[EXAMPLE] - Starting scene flow!"); 
            
            //This feature is implemented on BattleSettingsGeneratorService, creating a battle settings ready to inject to battle system
            var instantiateUnitService = ReferencesLocator.Instance.GetReference<InstantiateUnitEntityService>();
            var controller = instantiateUnitService.Instantiate<GenericEntityController>("Cultist");
        }

        protected override void StopSceneExecution()
        {
            Debug.Log("[EXAMPLE] - Stopping scene flow!");
        }
    }
}