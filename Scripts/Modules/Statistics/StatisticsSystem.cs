using System.Collections.Generic;
using System.Linq;
using Statistics.Persistence;
using Statistics.Ports;
using UnityEngine;

namespace Statistics
{
    public class StatisticsSystem : IStatisticsSystem
    {
        private Dictionary<string, float> statistics;
        private IStatisticsEventsEmitter eventsEmitter;
        
        public void SetData(IStatisticsEventsEmitter eventsEmitter)
        {
            this.eventsEmitter = eventsEmitter;
        }

        public void AddStatistic(string statisticKey, float value)
        {
            statistics[statisticKey] = statistics.TryGetValue(statisticKey, out var previousValue)
                ? value + previousValue
                : value;
            eventsEmitter.OnStatisticChanged(statisticKey,  previousValue+value);
        }

        public void SetStatistic(string statisticKey, float value)
        {
            statistics[statisticKey] = value;
            eventsEmitter.OnStatisticChanged(statisticKey,  value);
        }

        public bool HasStatistic(string statisticKey)
        {
            return statistics.ContainsKey(statisticKey);
        }

        public float GetStatisticFloat(string statisticKey)
        {
            return statistics.GetValueOrDefault(statisticKey, 0f);
        }

        public int GetStatisticInt(string statisticKey)
        {
            return statistics.TryGetValue(statisticKey, out var value) ? Mathf.RoundToInt(value) : 0;
        }

        public void Initialize()
        {
            statistics = new Dictionary<string, float>();
        }

        public void Dispose()
        {
            statistics.Clear();
            statistics = null;
        }
        
        public StatisticsPersistentData GetPersistentData()
        {
            return new StatisticsPersistentData()
            {
                statisticFields = statistics.Select(x => new StatisticFieldPersistentData()
                {
                    fieldId = x.Key,
                    value = x.Value
                }).ToList()
            };
        }

        public void LoadPersistentData(StatisticsPersistentData data)
        {
            statistics = data.statisticFields.ToDictionary(x => x.fieldId, x => x.value);
        }
    }
}