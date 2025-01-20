namespace Core.Save.Ports
{
    public interface IPersistentRepository<T>
    {
        T GetPersistentData();
        void SetLoadedData(T data);
        void ResetData();
    }
}