using System;
using UnityEngine;

namespace Game.Units
{
    [Serializable]
    public class UnitLevelAttributesDefinition
    {
        [SerializeField] private float health;
        [SerializeField] private float strength;
        [SerializeField] private float speed;

        public float Health => health;
        public float Strength => strength;
        public float Speed => speed;
    }
}