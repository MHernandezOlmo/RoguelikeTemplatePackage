using Entities.Ports;
using UnityEngine;

namespace Entities.Services
{
    public class EntityViewFactory : IEntityViewFactory
    {
        private IEntityViewIdFromTemplateType viewIdFromTemplateType;
        private IEntityViewTemplatesRepository viewTemplatesRepository;

        public void SetData(IEntityViewIdFromTemplateType viewIdFromTemplateType, IEntityViewTemplatesRepository viewTemplatesRepository)
        {
            this.viewIdFromTemplateType = viewIdFromTemplateType;
            this.viewTemplatesRepository = viewTemplatesRepository;
        }

        public EntityView GetViewForController<T>(object model, Vector3 position, Quaternion rotation) where T : IEntityController
        {
            var viewId = viewIdFromTemplateType.GetViewId<T>(model);
            var viewTemplate = viewTemplatesRepository.GetTemplate(viewId);
            var view = Object.Instantiate(viewTemplate, position, rotation);
            return view;
        }

        public bool RemoveView(EntityView entityControllerView)
        {
            if (entityControllerView == default) return false;
            
            Object.Destroy(entityControllerView.gameObject);
            return true;
        }
    }
}