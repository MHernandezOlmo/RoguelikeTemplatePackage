using System;
using System.Collections.Generic;

namespace Statistics.Persistence
{
    [Serializable]
    public class StatisticsPersistentData
    {
        public List<StatisticFieldPersistentData> statisticFields = new ();
    }
}