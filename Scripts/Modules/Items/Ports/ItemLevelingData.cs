using System.Collections.Generic;

namespace Items.Ports
{
    public interface IItemLevelingData
    {
        bool TryGetBonus(string bonusKey, out float value);
        IEnumerable<KeyValuePair<string, float>> GetBonuses();
    }
}