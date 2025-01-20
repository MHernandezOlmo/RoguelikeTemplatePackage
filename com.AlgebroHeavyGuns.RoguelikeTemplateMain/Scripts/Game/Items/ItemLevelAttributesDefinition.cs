using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Items
{
    [Serializable]
    public class ItemLevelAttributesDefinition
    {
        [SerializeField] private List<BonusDefinition> bonus;

        public IEnumerable<BonusDefinition> Bonus => bonus;
            
        [Serializable]
         public class BonusDefinition
        {
            public string Key;
            public float Value;
        }
    }
}