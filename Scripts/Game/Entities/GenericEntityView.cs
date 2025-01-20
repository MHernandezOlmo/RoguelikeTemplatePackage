using Entities.Ports;
using TMPro;
using UnityEngine;

namespace Game.Entities
{
    public class GenericEntityView : EntityView
    {
        [SerializeField] private TextMeshProUGUI entityForename;

        public void SetData(ModelData modelData)
        {
            entityForename.SetText(modelData.Forename);
        }
        
        public class ModelData
        {
            public string Forename { get; init; }
        }

    }
}