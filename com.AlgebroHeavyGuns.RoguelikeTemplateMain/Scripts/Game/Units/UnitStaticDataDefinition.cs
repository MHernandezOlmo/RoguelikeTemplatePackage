using System.Collections.Generic;
using UnityEngine;

namespace Game.Units
{
    [CreateAssetMenu(menuName = "Game/Units/Definition", fileName = "UnitStaticDataDefinition", order = 0)]
    public class UnitStaticDataDefinition : ScriptableObject
    {
        [SerializeField] private string unitForename;
        [SerializeField] private string imageKey;
        [SerializeField] private string entityViewId;
        [SerializeField] private List<UnitLevelAttributesDefinition> levelingAttributes;

        public IEnumerable<UnitLevelAttributesDefinition> LevelingAttributes => levelingAttributes;
        public string Forename => unitForename;
        public string ImageKey => imageKey;
        public string EntityViewId => entityViewId;
    }
}