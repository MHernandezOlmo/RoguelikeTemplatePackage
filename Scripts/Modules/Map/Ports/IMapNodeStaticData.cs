using System.Collections.Generic;

namespace Map.Ports
{
    public interface IMapNodeStaticData
    {
        string Id { get; }
        IEnumerable<string> RequiredNodes { get; }  //Nodes required to unlock this node.
        IEnumerable<string> UnlockNodes { get; }  //Nodes this node unlocks.
    }
}