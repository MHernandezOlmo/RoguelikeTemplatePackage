using System.Collections.Generic;

namespace Map.Ports
{
    public interface IMapController
    {
        string MapForename { get; }
        string MapId { get; }
        IEnumerable<MapNodeModel> Nodes { get; }
        bool IsCompleted { get; }
        void SetAsCompleted(string nodeId);
    }
}