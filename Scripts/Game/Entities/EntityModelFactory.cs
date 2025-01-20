using System;
using Entities.Ports;
using UnityEngine.Assertions;

namespace Game.Entities
{
    public class EntityModelFactory : IEntityModelFactory
    {
        private EntityAttributesFactory entityAttributesFactory;

        public void SetData(EntityAttributesFactory entityAttributesFactory)
        {
            this.entityAttributesFactory = entityAttributesFactory;
        }

        public object GetModelForController<T>(int id, object staticData) where T : IEntityController
        {
            var type = typeof(T);
            if (typeof(GenericEntityController).IsAssignableFrom(type))
            {
                Assert.IsTrue(staticData is GenericEntityController.StaticModel, ErrorMessageInvalidStatic(type));
                var genericStaticData = (GenericEntityController.StaticModel)staticData;
                var (currentAttributes, maxAttributes) = entityAttributesFactory.GenerateAttributesFromEntityData(genericStaticData);
                var model = new GenericEntityController.InnerModel(id, genericStaticData, currentAttributes, maxAttributes);
                return model;
            }
            
            throw new NotSupportedException(ErrorMessageNotFoundClass(type));
            //return default;
        }
        
        private static string ErrorMessageInvalidStatic(Type type) =>  $"Failed trying to create a model from {type} controller template class. Not valid static data.";
        private static string ErrorMessageNotFoundClass(Type type) =>  $"Failed trying to create a model from {type} template class . Unknown or missing-implementing class.";
    }
}