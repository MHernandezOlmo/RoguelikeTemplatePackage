using System;
using System.Collections.Generic;
using System.Linq;
using Common;
using UnityEngine;

namespace Game.Units.Graphics
{
    [CreateAssetMenu(menuName = "Game/Units/GenericImagesRepository", fileName = "New UnitGenericImageRepository", order = 0)]
    public class UnitGenericImageRepository : ScriptableObject, IRepository<Sprite, string>
    {
        [SerializeField] private List<PairNode> images;

        private Dictionary<string, Sprite> imageDictionary;
        
        public void Initialize()
        {
            imageDictionary = images.ToDictionary(x => x.Key, x => x.Icon);
        }
        
        public IEnumerable<Sprite> GetElements()
        {
            return imageDictionary.Values;
        }

        public bool TryGet(string key, out Sprite element)
        {
            return imageDictionary.TryGetValue(key, out element);
        }

        public Sprite Get(string key)
        {
            return imageDictionary[key];
        }

        [Serializable]
        public class PairNode
        {
            public string Key;
            public Sprite Icon;
        }
    }
}

namespace Game.Units.Graphics
{
}