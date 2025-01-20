using System;
using System.Collections.Generic;

namespace Map.Persistence
{
    [Serializable]
    public class MapProgressPersistentData
    {
        public string mapID;
        public List<string> completedNodeIds = new();
    }
}