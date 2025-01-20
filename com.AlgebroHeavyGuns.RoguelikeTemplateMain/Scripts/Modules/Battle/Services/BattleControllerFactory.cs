using Battle.Ports;

namespace Battle.Services
{
    
    public class BattleControllerFactory : IBattleControllerFactory
    {
        private IBattleResultCalculator resultCalculator;
        private IBattleFlowEventsEmitter flowEventsEmitter;
        
        public BattleController Create(IBattleSettings settings)
        {
            var model = new BattleModel(settings);
            var controller = new BattleController(model);
            controller.SetData(resultCalculator, flowEventsEmitter);
            controller.Initialize();
            return controller;
        }

        public void SetData(IBattleResultCalculator battleResultCalculator, IBattleFlowEventsEmitter battleFlowEventsEmitter)
        {
            resultCalculator = battleResultCalculator;
            flowEventsEmitter = battleFlowEventsEmitter;
        }
    }
}