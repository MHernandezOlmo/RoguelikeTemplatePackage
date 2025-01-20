namespace Core.Save.Ports
{
    public interface ISaveService
    {
        void Save();
        void RemoveSavedData();
        void ResetData();
    }
}