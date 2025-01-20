using System.Linq;
using Game.UI.Base;
using Game.UI.Widgets;
using Units.Ports;

namespace Game.UI.Controllers
{
    public class ExampleUnitCounterController : MenuController<ExampleUnitCounterPanel, ExampleUnitCounterUIService>
    {
        public ExampleUnitCounterController(ExampleUnitCounterPanel menuView, ExampleUnitCounterUIService dataService) : base(menuView, dataService) { }
        
        public override void Initialize()
        {
            var menuModel = DataService.GetPanelModel();
            MenuView.SetModel(menuModel);
        }

        public override void Dispose()
        {

        }

        public override void Refresh()
        {
            MenuView.Refresh();
        }
    }
    
    
    public class ExampleUnitCounterUIService
    {
        private IUnitsSystem unitsSystem;
        
        public void SetData(IUnitsSystem unitsSystem)
        {
            this.unitsSystem = unitsSystem;
        }

        public ExampleUnitCounterPanel.IModel GetPanelModel()
        {
            return new PanelModel{ UnitCount = unitsSystem.GetAllUnits().Count() };
        }
        
        private class PanelModel : ExampleUnitCounterPanel.IModel
        {
            public int UnitCount { get; set; }
        }
    }
}