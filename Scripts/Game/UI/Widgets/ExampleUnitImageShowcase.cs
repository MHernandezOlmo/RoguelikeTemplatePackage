using Game.UI.Base;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI.Widgets
{
    public class ExampleUnitImageShowcaseWidget : Widget<ExampleUnitImageShowcaseWidget.IModel, ExampleUnitImageShowcaseWidget.IListener>
    {
        [SerializeField] private string unitIdToShow;
        [SerializeField] private Image unitImage;
        
        public string UnitIdToShow => unitIdToShow;
        
        public override void Refresh()
        {
            unitImage.sprite = Model.UnitImage;
        }
        

        public interface IModel
        {
            Sprite UnitImage { get; }
        }
        
        public interface IListener
        {
            
        }
    }
}