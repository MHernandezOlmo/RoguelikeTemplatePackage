using System;
using Game.Entities;
using Units.Ports;

namespace Game.Units
{
    public static class UnitStaticToEntityStaticConverter
    {
        public static object ConvertToEntityStatic<T>(IUnitModel model)
        {
            var type = typeof(T);
            if (typeof(GenericEntityController).IsAssignableFrom(type))
            {
                var controllerStaticData = new GenericEntityController.StaticModel()
                {
                    ViewId = model.StaticData.ViewId,
                    EntityForename = model.StaticData.Forename,
                    TemplateId = model.StaticData.Id
                };
                return controllerStaticData;
            }
            
            throw new NotSupportedException();
            //return default;
        }
    }
}