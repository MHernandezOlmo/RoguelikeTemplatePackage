using System;
using Entities.Ports;
using UnityEngine.Assertions;

namespace Game.Entities
{
    public class EntityViewIdFromTemplateType : IEntityViewIdFromTemplateType
    {
        public string GetViewId<T>(object model) where T : IEntityController
        {
            var type = typeof(T);
            if (typeof(GenericEntityController).IsAssignableFrom(type))
            {
                Assert.IsTrue(model is GenericEntityController.InnerModel, ErrorMessageInvalidModel(type));
                var templateModel = (GenericEntityController.InnerModel)model;
                return templateModel.Static.ViewId;
            }
            
            throw new NotSupportedException(ErrorMessageNotFoundClass(type));
            //return default;
        }
        
        private static string ErrorMessageInvalidModel(Type type) =>  $"Failed trying to get view id from {type} model. Not valid model.";
        private static string ErrorMessageNotFoundClass(Type type) =>  $"Failed trying to create a model from {type} template class . Unknown or missing-implementing class.";
        
    }
}