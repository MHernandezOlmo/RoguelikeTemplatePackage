using Entities.Ports;
using UnityEngine;

namespace Entities.Services
{
    public class EntityFactory : IEntityFactory
    {
        private IEntityModelFactory entityModelFactory;
        private IEntityViewFactory entityViewFactory;
        private IEntityControllerBuilder entityControllerBuilder;

        public void SetData(IEntityModelFactory entityModelFactory, IEntityViewFactory entityViewFactory, IEntityControllerBuilder entityControllerBuilder)
        {
            this.entityModelFactory = entityModelFactory;
            this.entityViewFactory = entityViewFactory;
            this.entityControllerBuilder = entityControllerBuilder;
        }

        public T CreateEntity<T>(int id, Vector3 position, Quaternion rotation, object staticData) where T : IEntityController
        {
            var model = entityModelFactory.GetModelForController<T>(id, staticData);
            var view = entityViewFactory.GetViewForController<T>(model, position, rotation);
            var controller = CreateController<T>(model, view);
            return controller;
        }
        
        public T CreateEntity<T>(int id, EntityView view, object staticData) where T : IEntityController
        {
            var model = entityModelFactory.GetModelForController<T>(id, staticData);
            var controller = CreateController<T>(model, view);
            return controller;
        }

        public bool RemoveEntity(IEntityController entityController)
        {
            return entityViewFactory.RemoveView(entityController.View);
        }
        
        private T CreateController<T>(object model, EntityView view) where T : IEntityController
        {
            var controller = entityControllerBuilder.Build<T>(model, view);
            return controller;
        }
    }
}