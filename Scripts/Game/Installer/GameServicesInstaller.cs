using Battle.Ports;
using Core.Install.Base;
using Core.Install.Ports;
using Entities.Ports;
using Game.Battle;
using Game.Battle.Services;
using Game.Entities;
using Game.Inventory;
using Game.Items;
using Game.Simulation;
using Game.UI.Services;
using Items.Ports;
using Simulation.Ports;
using Units.Ports;
using User.Ports;

namespace Game.Installer
{
    public class GameServicesInstaller : IDependencyInstaller
    {
        //BATTLE
        private readonly GameBattleResultCalculator battleResultCalculator = new();
        private readonly BattleSettingsGeneratorService battleSettingsGeneratorService = new();
        private readonly BattleActionsTriggerEventsListener battleActionsTriggerEventsListener = new();
        private readonly BattleTriggerActionApplicator battleTriggerActionApplicator = new();
        
        //ENTITIES
        private readonly InstantiateUnitEntityService instantiateUnitEntityService = new();
        private readonly EntitiesFlowEventsListener entitiesFlowEventsListener = new();
        private readonly EntitiesBattleActionsTriggerListener entitiesBattleActionsTriggerListener = new();
        private readonly ItemsBattleActionsTriggerListener itemsBattleActionsTriggerListener = new();
        
        //SIMULATION
        private readonly GameActionApplicatorRepository actionApplicatorRepository = new();
        
        //UI
        private readonly UIBattleFlowEventsListener uiBattleFlowEventsListener = new();
        
        public void DefineReferences(IReferencesRepository referencesLocator)
        {
            referencesLocator.AddReference<IBattleResultCalculator>(battleResultCalculator);
            referencesLocator.AddReference<IActionApplicatorRepository>(actionApplicatorRepository);
            referencesLocator.AddReference<IBattleActionsTriggerEventsListener>(battleActionsTriggerEventsListener);
            referencesLocator.AddReference(entitiesFlowEventsListener);
            referencesLocator.AddReference(uiBattleFlowEventsListener);
            referencesLocator.AddReference(battleSettingsGeneratorService);
            referencesLocator.AddReference(battleResultCalculator);
            referencesLocator.AddReference(instantiateUnitEntityService);
        }

        public void Install(IReferencesRepository referencesLocator)
        {
            var unitsSystem = referencesLocator.GetReference<IUnitsSystem>();
            var itemsSystem = referencesLocator.GetReference<IItemsSystem>();
            var battleSystem = referencesLocator.GetReference<IBattleSystem>();
            var entitiesSystem = referencesLocator.GetReference<IEntitiesSystem>();
            var uiControllersReferences = referencesLocator.GetReference<IUIControllerReferences>();
            var userDataSystem = referencesLocator.GetReference<IUserDataSystem>();
            
            battleResultCalculator.SetData(battleSystem, entitiesSystem);
            battleSettingsGeneratorService.SetData(instantiateUnitEntityService);
            instantiateUnitEntityService.SetData(entitiesSystem, unitsSystem);
            entitiesFlowEventsListener.SetData(entitiesSystem);
            uiBattleFlowEventsListener.SetData(uiControllersReferences);
            UserInventoryToBonusConverter.SetData(userDataSystem, itemsSystem);
            battleActionsTriggerEventsListener.SetData(itemsBattleActionsTriggerListener, entitiesBattleActionsTriggerListener);
            battleTriggerActionApplicator.SetData();
            itemsBattleActionsTriggerListener.SetData(itemsSystem, userDataSystem, battleTriggerActionApplicator);
            entitiesBattleActionsTriggerListener.SetData();

        }

        public void Uninstall(IReferencesRepository referencesLocator)
        {
            referencesLocator.RemoveReference<IBattleResultCalculator>();
            referencesLocator.RemoveReference<BattleSettingsGeneratorService>();
            referencesLocator.RemoveReference<InstantiateUnitEntityService>();
            referencesLocator.RemoveReference<IActionApplicatorRepository>();
        }
    }
}