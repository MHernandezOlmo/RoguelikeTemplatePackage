using System.Collections.Generic;
using Entities.Ports;
using UnityEngine;

namespace Game.Skills.Graphics
{
    [CreateAssetMenu(menuName = "Game/Skills/GraphicRepository", fileName = "Skill Graphics Repository", order = -100)]
    public class SkillGraphicsRepository : ScriptableObject, ISkillGraphicsRepository
    {
        [SerializeField] private SkillImageRepository imageRepository;

        public bool TryGetSkillImage(string key, out Sprite image) => imageRepository.TryGet(key, out image);

        public IEnumerable<Sprite> GetAllSkillImages() => imageRepository.GetElements();

        public void Initialize()
        {
            imageRepository.Initialize();
        }
    }
}
