namespace Map.Persistence
{
    public interface IMapProgressModulePersistence
    {
        MapsProgressPersistentData GeneratePersistentData();
        void LoadPersistentData(MapsProgressPersistentData data);
        void ResetPersistentData();
    }
}