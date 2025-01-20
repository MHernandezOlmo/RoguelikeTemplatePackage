using System.Collections.Generic;
using UnityEngine;

namespace Game.Items.Graphics
{
    [CreateAssetMenu(menuName = "Game/Items/GraphicRepository", fileName = "Items Graphics Repository", order = -100)]
    public class ItemGraphicsRepository : ScriptableObject, IItemGraphicsRepository
    {
        [SerializeField] private ItemGenericImageRepository imageRepository;

        public bool TryGetItemGenericImage(string key, out Sprite image) => imageRepository.TryGet(key, out image);

        public IEnumerable<Sprite> GetAllItemsGenericImages() => imageRepository.GetElements();

        public void Initialize()
        {
            imageRepository.Initialize();
        }
    }
}