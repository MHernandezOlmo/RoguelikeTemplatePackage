using Game.UI.Widgets;
using Game.Units.Graphics;
using Units.Ports;
using UnityEngine;

namespace Game.UI.Controllers
{
    public class ExampleUnitImageShowcaseController : Base.MenuController<ExampleUnitImageShowcaseWidget, ExampleUnitImagesUIService>
    {
        public ExampleUnitImageShowcaseController(ExampleUnitImageShowcaseWidget menuView, ExampleUnitImagesUIService dataService) : base(menuView, dataService) { }
        
        public override void Initialize()
        {
            var panelModel = DataService.GetPanelModel(MenuView.UnitIdToShow);
            MenuView.SetModel(panelModel);
        }

        public override void Dispose()
        {
            
        }

        public override void Refresh()
        {
            MenuView.Refresh();
        }
    }
    
    public class ExampleUnitImagesUIService
    {
        private IUnitsSystem unitsSystem;
        private IUnitGraphicsRepository unitGraphicsRepository;
        
        public void SetData(IUnitsSystem unitsSystem, IUnitGraphicsRepository unitGraphicsRepository)
        {
            this.unitsSystem = unitsSystem;
            this.unitGraphicsRepository = unitGraphicsRepository;
        }

        public ExampleUnitImageShowcaseWidget.IModel GetPanelModel(string unitId)
        {
            if (!unitsSystem.TryGetUnit(unitId.GetHashCode(), out var unitModel))
            {
                Debug.LogError($"Not found unit with id={unitId}");
                return null;
            }

            if (!unitGraphicsRepository.TryGetUnitGenericImage(unitModel.StaticData.BasicImageKey,
                    out var unitBasicImage))
            {
                Debug.LogError(
                    $"Not found image for unit {unitId} with ImageId={unitModel.StaticData.BasicImageKey}");
                return null;
            }

            return new PanelModel() { UnitImage = unitBasicImage };
        }
        
        private class PanelModel : ExampleUnitImageShowcaseWidget.IModel
        {
            public Sprite UnitImage { get; set; }
        }
    }
}