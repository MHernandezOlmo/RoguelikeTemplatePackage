namespace Map.Ports
{
    public interface IMapNodeModel
    {
        bool IsAvailable { get; }
        bool IsCompleted { get; }
        IMapNodeStaticData StaticData { get; }
    }
}