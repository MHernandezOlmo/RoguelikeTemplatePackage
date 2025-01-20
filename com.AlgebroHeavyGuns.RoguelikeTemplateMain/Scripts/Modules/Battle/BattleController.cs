using Battle.Ports;

namespace Battle
{
    public class BattleController : IBattleController
    {
        public IBattleModel Model => model;
        public bool IsFinished => Result != eBattleResult.IN_PROGRESS;
        public bool HasQuitBattle { get; private set; } = false;
        public eBattleResult Result
        {
            get
            {
                if (isResultDirty)
                    RefreshResult();
                return cachedResult;
            }
        }

        private readonly BattleModel model;
        
        private IBattleResultCalculator resultCalculator;
        private IBattleFlowEventsEmitter eventsEmitter;
        private bool isResultDirty;
        private eBattleResult cachedResult;

        public BattleController(BattleModel battleModel)
        {
            model = battleModel;
        }
        
        public void SetData(IBattleResultCalculator battleResultCalculator, IBattleFlowEventsEmitter battleFlowEventsEmitter)
        {
            resultCalculator = battleResultCalculator;
            eventsEmitter = battleFlowEventsEmitter;
        }

        public void StartBattle()
        {
            cachedResult = eBattleResult.IN_PROGRESS;
            isResultDirty = true;
        }
        

        public void QuitBattle()
        {
            HasQuitBattle = true;
            isResultDirty = true;
        }

        public void OnUnitDead(int unitId)
        {
            isResultDirty = true;
        }

        public void GoNextTurn()
        {
            model.CurrentTurn = model.CurrentTurn == IBattleSettings.Team.PLAYER
                ? IBattleSettings.Team.RIVAL
                : IBattleSettings.Team.PLAYER;
            eventsEmitter.OnTurnChanged(model.CurrentTurn); 
        }

        private void RefreshResult()
        {
            cachedResult = HasQuitBattle ? eBattleResult.RUN_AWAY : resultCalculator.GetResult(this);
            isResultDirty = false;
        }

        public void Initialize()
        {
            cachedResult = eBattleResult.BAD_STATE;
            isResultDirty = true;
            HasQuitBattle = false;
        }

        public void Dispose()
        {
            model.Dispose();
        }
        
    }
}