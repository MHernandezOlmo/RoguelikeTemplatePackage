using UnityEngine;

namespace Entities.Ports
{
    public interface IEntityViewFactory
    {
        EntityView GetViewForController<T>(object model, Vector3 position, Quaternion rotation) where T : IEntityController;
        bool RemoveView(EntityView entityControllerView);
    }
    public interface IEntityModelFactory
    {
        object GetModelForController<T>(int id, object staticData) where T : IEntityController;
    }

    public interface IEntityControllerBuilder
    {
        T Build<T>(object model, EntityView view);
    }

    public interface IEntityViewTemplatesRepository
    {
        EntityView GetTemplate(string viewId);
    }

    public interface IEntityViewIdFromTemplateType
    {
        string GetViewId<T>(object model) where T : IEntityController;
    }
}