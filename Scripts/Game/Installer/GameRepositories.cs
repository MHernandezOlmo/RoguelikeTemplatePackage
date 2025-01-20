using Core.Install.Ports;
using Entities.Ports;
using Game.Items;
using Game.Items.Graphics;
using Game.Maps;
using Game.Skills;
using Game.Skills.Graphics;
using Game.Units;
using Game.Units.Graphics;
using Items.Ports;
using Map.Ports;
using Skills.Ports;
using Units.Ports;
using UnityEngine;

namespace Game.Installer
{
    [CreateAssetMenu(menuName = "Game/GameRepositories", fileName = "new GameRepositories", order = 0)]
    public class GameRepositories : ScriptableObject
    {
        [Header("Static Data")]
        [SerializeField] private UnitStaticDataRepository unitStaticDataRepository;
        [SerializeField] private ItemStaticDataRepository itemStaticDataRepository;
        [SerializeField] private SkillStaticDataRepository skillStaticDataRepository;
                
        [SerializeField] private MapsStaticRepository mapsStaticRepository;
        
        [Header("Graphics")]
        [SerializeField] private UnitGraphicsRepository unitGraphicsRepository;
        [SerializeField] private ItemGraphicsRepository itemGraphicsRepository;
        [SerializeField] private SkillGraphicsRepository skillGraphicsRepository;
        
        public void DefineReferences(IReferencesRepository referencesRepository)
        {
            referencesRepository.AddReference<IEntityViewTemplatesRepository>(unitGraphicsRepository);    
            referencesRepository.AddReference<IUnitStaticDataRepository>(unitStaticDataRepository);
            referencesRepository.AddReference<IUnitGraphicsRepository>(unitGraphicsRepository);
            referencesRepository.AddReference<IItemStaticDataRepository>(itemStaticDataRepository);
            referencesRepository.AddReference<IItemGraphicsRepository>(itemGraphicsRepository);
            referencesRepository.AddReference<IMapsStaticRepository>(mapsStaticRepository);
            referencesRepository.AddReference<ISkillStaticDataRepository>(skillStaticDataRepository);
            referencesRepository.AddReference<ISkillGraphicsRepository>(skillGraphicsRepository);
            
            unitStaticDataRepository.Initialize();  //forced to create a dictionary internally.
            unitGraphicsRepository.Initialize();  //forced to create a dictionary internally.
            itemStaticDataRepository.Initialize(); //forced to create a dictionary internally.
            itemGraphicsRepository.Initialize(); //forced to create a dictionary internally.
            skillStaticDataRepository.Initialize();  //forced to create a dictionary internally.
            skillGraphicsRepository.Initialize();  //forced to create a dictionary internally.
        }

        public void Unistall(IReferencesRepository referencesRepository)
        {
            referencesRepository.RemoveReference<IEntityViewTemplatesRepository>();
            referencesRepository.RemoveReference<IUnitStaticDataRepository>();
            referencesRepository.RemoveReference<IUnitGraphicsRepository>();
            referencesRepository.RemoveReference<IItemStaticDataRepository>();
            referencesRepository.RemoveReference<IItemGraphicsRepository>();
            referencesRepository.RemoveReference<ISkillStaticDataRepository>();
            referencesRepository.RemoveReference<ISkillGraphicsRepository>();
        }
    }
}