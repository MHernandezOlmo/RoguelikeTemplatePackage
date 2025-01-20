using System.Collections.Generic;

namespace Map.Ports
{
    public interface IMapStaticModel
    {
        string MapForename { get; }
        string MapId { get; }
        IEnumerable<IMapNodeStaticData> Nodes { get; }
    }
}