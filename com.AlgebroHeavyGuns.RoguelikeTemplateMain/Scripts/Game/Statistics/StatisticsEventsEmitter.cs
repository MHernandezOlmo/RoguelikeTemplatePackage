using Core.Save.Ports;
using Statistics.Ports;

namespace Game.Statistics
{
    public class StatisticsEventsEmitter : IStatisticsEventsEmitter
    {
        private ISaveService saveService;

        public void SetData(ISaveService saveService)
        {
            this.saveService = saveService;
        }
        
        public void OnStatisticChanged(string statisticKey, float value)
        {
            saveService.Save();
        }
    }
}
