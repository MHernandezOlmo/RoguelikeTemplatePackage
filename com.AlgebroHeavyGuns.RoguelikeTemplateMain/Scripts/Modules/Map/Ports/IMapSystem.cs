namespace Map.Ports
{
    public interface IMapSystem
    {
        bool TryGetMap(string mapId, out IMapController mapController);
    }
}