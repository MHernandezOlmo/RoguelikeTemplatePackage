using System;
using Entities.Ports;
using UnityEngine.Assertions;

namespace Game.Entities
{
    public class EntityControllerBuilder : IEntityControllerBuilder
    {
        public T Build<T>(object model, EntityView view)
        {
            var type = typeof(T);
            if (typeof(GenericEntityController).IsAssignableFrom(type))
            {
                Assert.IsTrue(model is GenericEntityController.InnerModel, ErrorMessageInvalidModel(type));
                Assert.IsTrue(view is GenericEntityView, ErrorMessageInvalidView(type));
                var controller = new GenericEntityController((GenericEntityController.InnerModel)model,  (GenericEntityView)view);
                controller.Initialize();
                return (T)(IEntityController)controller;
            }
            
            throw new NotSupportedException(ErrorMessageNotFoundClass(type));
            //return default;
        }
        
        private static string ErrorMessageInvalidModel(Type type) =>  $"Failed trying to create a {type} from a invalid model.";
        private static string ErrorMessageInvalidView(Type type) =>  $"Failed trying to create a {type} from a invalid view type.";
        private static string ErrorMessageNotFoundClass(Type type) =>  $"Failed trying to create a {type} . Unknown or missing-implementing class.";
    }
}