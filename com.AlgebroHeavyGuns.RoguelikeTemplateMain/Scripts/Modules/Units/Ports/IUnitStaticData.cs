using System.Collections.Generic;

namespace Units.Ports
{
    public interface IUnitStaticData
    {
        string Forename { get; }
        int Id { get; }
        string BasicImageKey { get; }
        IEnumerable<IUnitLevelingData> AttributesAtAllLevels { get; }
        IUnitLevelingData AttributesAtLevel(int level);
        int MaxLevel { get; }
        string ViewId { get; }
    }
}