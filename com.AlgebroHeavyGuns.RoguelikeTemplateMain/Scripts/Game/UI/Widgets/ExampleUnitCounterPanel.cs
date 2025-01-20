using TMPro;
using UnityEngine;

namespace Game.UI.Widgets
{
    public class ExampleUnitCounterPanel : Base.Widget<ExampleUnitCounterPanel.IModel, ExampleUnitCounterPanel.IListener>
    {
        [SerializeField] private TextMeshProUGUI countLabel;
        
        public override void Refresh()
        {
            countLabel.SetText(Model.UnitCount.ToString());
        }
        

        public interface IModel
        {
            int UnitCount { get; }
        }
        
        public interface IListener
        {
            
        }
    }
}


