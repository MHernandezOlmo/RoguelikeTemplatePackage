using Map.Ports;

namespace Map
{
    public class MapNodeModel : IMapNodeModel
    {
        public bool IsAvailable { get; set; }
        public bool IsCompleted { get; set; }
        public IMapNodeStaticData StaticData { get; }

        public MapNodeModel(IMapNodeStaticData staticData)
        {
            StaticData = staticData;
        }
    }
}