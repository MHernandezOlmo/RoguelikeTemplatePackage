using System.Collections.Generic;

namespace Units.Ports
{
    public interface IUnitLevelingData
    {
        bool TryGetAttribute(int attributeKey, out float value);
        IEnumerable<KeyValuePair<int, float>> Attributes { get; }
    }
}