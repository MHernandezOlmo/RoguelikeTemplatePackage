using System.Collections.Generic;
using Entities.Ports;
using Entities.Services;

namespace Game.Entities
{
    public partial class GenericEntityController
    {
        public class InnerModel : IEntityModel
        {
            public int Id { get; }
            public IEntityStatistic Statistic => entityStatistics;
            public IEntityStaticModel Static => staticModel;

            private readonly Dictionary<int, float> currentAttributes;
            private readonly Dictionary<int, float> maxAttributes;

            private readonly StaticModel staticModel;

            private readonly EntityStatistics entityStatistics = new();

            public InnerModel(int id, StaticModel staticModel, Dictionary<int, float> currentAttributes,
                Dictionary<int, float> maxAttributes)
            {
                Id = id;
                this.staticModel = staticModel;
                this.currentAttributes = currentAttributes;
                this.maxAttributes = maxAttributes;
            }

            public IEntityAlteredStateManager AlteredStateManager { get; } = new EntityAlteredStateManager();

            public bool TryGetCurrentAttribute(int attributeKey, out float value)
            {
                return currentAttributes.TryGetValue(attributeKey, out value);
            }

            public bool TryGetMaxAttribute(int attributeKey, out float value)
            {
                return maxAttributes.TryGetValue(attributeKey, out value);
            }

            public void SetCurrentAttribute(int attributeKey, float value)
            {
                currentAttributes[attributeKey] = value;
            }

            public void SetMaxAttribute(int attributeKey, float value)
            {
                maxAttributes[attributeKey] = value;
            }

            public void AddCurrentAttribute(int attributeKey, float value)
            {
                currentAttributes[attributeKey] = currentAttributes.TryGetValue(attributeKey, out var previous)
                    ? previous + value
                    : value;
            }

            public void AddMaxAttribute(int attributeKey, float value)
            {
                maxAttributes[attributeKey] = maxAttributes.TryGetValue(attributeKey, out var previous)
                    ? previous + value
                    : value;
            }
        }

        public class StaticModel : IEntityStaticModel
        {
            public string ViewId { get; init; }
            public int TemplateId { get; set; }
            public string EntityForename { get; init; }
            public int Level { get; init; }
        }
    }
}