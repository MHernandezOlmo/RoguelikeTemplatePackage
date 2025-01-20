using System.Collections.Generic;
using Entities.Ports;
using UnityEngine;

namespace Game.Entities
{
    public partial class GenericEntityController : IEntityController
    {
        public int Id => model.Id;
        public uint Team { get; set; }
        public EntityView View => view;
        public IEntityModel Model => model;

        public bool IsAlive => model.TryGetCurrentAttribute(EntityAttributesConstants.HEALTH, out var currentHealth) && currentHealth > 0f;

        private readonly InnerModel model;
        private readonly GenericEntityView view;

        public GenericEntityController(InnerModel model, GenericEntityView view)
        {
            this.model = model;
            this.view = view;
        }
        
        public void ApplyHealthVariation(float healthVariation)
        {
            ApplyVariationClampedByMax(EntityAttributesConstants.HEALTH, healthVariation);
        }

        private void ApplyVariationClampedByMax(int attribute, float variation)
        {
            model.TryGetCurrentAttribute(attribute, out var current);
            model.TryGetMaxAttribute(attribute, out var max);
            model.SetCurrentAttribute(attribute, Mathf.Clamp(current + variation, 0f, max));
        }

        public void Tick(float deltaTime)
        {
            // do nothing.
        }

        public void Initialize()
        {
            view.SetData(new GenericEntityView.ModelData()
            {
                Forename = model.Static.EntityForename,
            });
        }
    }
}