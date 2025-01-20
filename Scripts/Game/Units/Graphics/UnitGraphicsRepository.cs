using System.Collections.Generic;
using Entities.Ports;
using UnityEngine;

namespace Game.Units.Graphics
{
    [CreateAssetMenu(menuName = "Game/Units/GraphicRepository", fileName = "Unit Graphics Repository", order = -100)]
    public class UnitGraphicsRepository : ScriptableObject, IUnitGraphicsRepository
    {
        [SerializeField] private UnitGenericImageRepository imageRepository;
        [SerializeField] private UnitViewTemplatesRepository viewTemplatesRepository;

        public bool TryGetUnitGenericImage(string key, out Sprite image) => imageRepository.TryGet(key, out image);

        public IEnumerable<Sprite> GetAllUnitGenericImages() => imageRepository.GetElements();

        public void Initialize()
        {
            imageRepository.Initialize();
            viewTemplatesRepository.Initialize();
        }

        public EntityView GetTemplate(string viewId) => viewTemplatesRepository.Get(viewId);
    }
}
