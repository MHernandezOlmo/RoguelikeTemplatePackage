using System.Collections.Generic;
using Entities.Ports;
using UnityEngine;

namespace Game.Entities
{
    public class EntityStatistics : IEntityStatistic
    {
        private readonly Dictionary<string, float> statistics = new();
        
        public void AddStatistic(string statisticKey, float value)
        {
            statistics[statisticKey] = statistics.TryGetValue(statisticKey, out var previousValue)
                ? value + previousValue
                : value;
        }

        public void SetStatistic(string statisticKey, float value)
        {
            statistics[statisticKey] = value;
        }

        public float GetStatisticFloat(string statisticKey)
        {
            return statistics.GetValueOrDefault(statisticKey, 0f);
        }

        public int GetStatisticInt(string statisticKey)
        {
            return statistics.TryGetValue(statisticKey, out var value) ? Mathf.RoundToInt(value) : 0;
        }
    }
}