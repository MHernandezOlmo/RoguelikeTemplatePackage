using Battle.Ports;

namespace Battle
{
    public class BattleSystem : IBattleSystem
    {
        public bool IsBattleActive => controller != null;
        public IBattleController Battle => controller;
        
        private IBattleControllerFactory factory;
        private BattleController controller;

        public void SetData(IBattleControllerFactory factory)
        {
            this.factory = factory;
        }

        public IBattleController CreateBattle(IBattleSettings settings)
        {
            controller = factory.Create(settings);
            return controller;
        }

        public void CloseBattle()
        {
            controller?.Dispose();
            controller = null;
        }

        public void Initialize()
        {

        }

        public void Dispose()
        {
            CloseBattle();
        }

        public void Tick(float deltaTime)
        {
        }
    }

}

