using System.Collections.Generic;
using System.Linq;
using Skills.Ports;
using UnityEngine;

namespace Game.Skills
{
    
    [CreateAssetMenu(menuName = "Game/Skills/Repository", fileName = "SkillStaticDataRepository", order = 0)]
    public class SkillStaticDataRepository : ScriptableObject ,  ISkillStaticDataRepository
    {
        [SerializeField] private List<SkillStaticDataDefinition> skillsDefinitions;

        private Dictionary<string, ISkillStaticData> staticData;


        public void Initialize()
        {
            staticData = skillsDefinitions.ToDictionary(
                x => x.Forename, 
                x => new SkillStaticData(x) as ISkillStaticData);
        }
        
        public IEnumerable<ISkillStaticData> GetElements()
        {
            return staticData.Values;
        }

        public bool TryGet(string key, out ISkillStaticData element)
        {
            return staticData.TryGetValue(key, out element);
        }

        public ISkillStaticData Get(string key)
        {
            return staticData[key];
        }
    }
}