using Core.Install.Base;
using Core.Install.Ports;
using Entities;
using Entities.Ports;
using Entities.Services;
using Game.Entities;
using Units.Ports;


namespace Game.Installer.Modules
{
    public class EntitiesModuleInstaller : ISystemInstaller
    {
        //DOMAIN
        private readonly EntitiesSystem entitiesSystem = new();
        private readonly EntityFactory entityFactory = new();
        private readonly EntityViewFactory entityViewFactory = new();
        
        //GAME SERVICES
        private readonly EntityModelFactory entityModelFactory = new();
        private readonly EntityAttributesFactory entityAttributesFactory = new();
        private readonly EntityControllerBuilder entityControllerBuilder = new();
        private readonly EntityViewIdFromTemplateType entityViewIdFromTemplateType = new();
        
        public void DefineReferences(IReferencesRepository referencesLocator)
        {
            referencesLocator.AddReference<IEntitiesSystem>(entitiesSystem);
        }

        public void Install(IReferencesRepository referencesLocator)
        {
            var viewTemplatesRepository = referencesLocator.GetReference<IEntityViewTemplatesRepository>();
            var unitsSystem = referencesLocator.GetReference<IUnitsSystem>();
            
            entityViewFactory.SetData(entityViewIdFromTemplateType, viewTemplatesRepository);
            entityAttributesFactory.SetData(unitsSystem);
            entityModelFactory.SetData(entityAttributesFactory);
            entityFactory.SetData(entityModelFactory, entityViewFactory, entityControllerBuilder);
            entitiesSystem.SetData(entityFactory);
        }

        public void Uninstall(IReferencesRepository referencesLocator)
        {
            referencesLocator.RemoveReference<IEntitiesSystem>();
        }

        public void Initialize()
        {
            entitiesSystem.Initialize();
        }

        public void Dispose()
        {
            entitiesSystem.Dispose();
        }

        public void Tick(float deltaTime)
        {
            entitiesSystem.Tick(deltaTime);
        }
    }
}
