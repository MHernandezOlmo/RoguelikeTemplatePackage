using System.Collections.Generic;

namespace Items.Ports
{
    public interface IItemStaticData
    {
        string Forename { get; }
        int Id { get; }
        eItemRarity Rarity { get; }
        string ItemImageKey { get; }
        IEnumerable<IItemLevelingData> AttributesAtAllLevels { get; }
        IItemLevelingData AttributesAtLevel(int level);
        int MaxLevel { get; }
        IEnumerable<KeyValuePair<int, string>> SkillTriggers { get; }
    }
}