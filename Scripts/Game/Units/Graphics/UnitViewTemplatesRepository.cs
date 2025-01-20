using System;
using System.Collections.Generic;
using System.Linq;
using Common;
using Entities.Ports;
using UnityEngine;

namespace Game.Units.Graphics
{
    [CreateAssetMenu(menuName = "Game/Units/EntityTemplateRepository", fileName = "UnitViewTemplatesRepository", order = -10)]
    public class UnitViewTemplatesRepository : ScriptableObject, IRepository<EntityView, string>
    {
        [SerializeField] private List<PairNode> views;

        private Dictionary<string, EntityView> templatesDictionary;
        
        public void Initialize()
        {
            templatesDictionary = views.ToDictionary(x => x.Key, x => x.View);
        }
        
        public IEnumerable<EntityView> GetElements()
        {
            return templatesDictionary.Values;
        }

        public bool TryGet(string key, out EntityView element)
        {
            return templatesDictionary.TryGetValue(key, out element);
        }

        public EntityView Get(string key)
        {
            return templatesDictionary[key];
        }

        [Serializable]
        public class PairNode
        {
            public string Key;
            public EntityView View;
        }
    }
}