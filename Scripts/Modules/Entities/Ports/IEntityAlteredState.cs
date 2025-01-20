namespace Entities.Ports
{
    public interface IEntityAlteredState
    {
        string Key { get; }
        int Accumulations { get; }
        int Duration { get; }
    }
}