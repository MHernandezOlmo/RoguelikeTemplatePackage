namespace Core.Save.Ports
{
    public interface IPersistenceAdapter
    {
        void Save<T>(string identifier, T obj);
        T Load<T>(string identifier);
        bool HasSavedFile(string identifier);
        void RemoveFile(string identifier);
        void Initialize();
        void Dispose();

    }
}