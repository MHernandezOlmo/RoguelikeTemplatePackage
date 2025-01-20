using Battle;
using Battle.Ports;
using Battle.Services;
using Core.Install.Base;
using Core.Install.Ports;
using Game.Battle;
using Game.Entities;
using Game.UI.Services;


namespace Game.Installer.Modules
{
    public class BattleModuleInstaller  : ISystemInstaller
    {
        //DOMAIN
        private readonly BattleSystem system = new();
        
        //SERVICES
        private readonly BattleFlowEventsEmitter battleFlowEventsEmitter = new();

        public void DefineReferences(IReferencesRepository referencesLocator)
        {
            referencesLocator.AddReference<IBattleSystem>(system);
        }

        public void Install(IReferencesRepository referencesLocator)
        {
            var battleResultCalculator = referencesLocator.GetReference<IBattleResultCalculator>();

            var controllerFactory = new BattleControllerFactory();
            
            battleFlowEventsEmitter.SetData(referencesLocator.GetReference<EntitiesFlowEventsListener>(), 
                referencesLocator.GetReference<UIBattleFlowEventsListener>());
            controllerFactory.SetData(battleResultCalculator, battleFlowEventsEmitter);
            
            system.SetData(controllerFactory);
        }

        public void Uninstall(IReferencesRepository referencesLocator)
        {
            referencesLocator.RemoveReference<IBattleSystem>();
        }

        public void Initialize()
        {
            system.Initialize();
        }

        public void Dispose()
        {
            system.Dispose();
        }

        public void Tick(float deltaTime)
        {
            system.Tick(deltaTime);
        }
    }
}