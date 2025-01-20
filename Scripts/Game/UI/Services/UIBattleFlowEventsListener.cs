using Battle.Ports;
using Game.Installer;

namespace Game.UI.Services
{
    public class UIBattleFlowEventsListener
    {
        private IUIControllerReferences uiControllersReferences;
        
        public void SetData(IUIControllerReferences uiControllersReferences)
        {
            this.uiControllersReferences = uiControllersReferences;
        }
        
        public void OnTurnChanged(IBattleSettings.Team currentTurnTeam)
        {
            //DO UI THINGS ABOUT TURN CHANGING
        }


    }
}