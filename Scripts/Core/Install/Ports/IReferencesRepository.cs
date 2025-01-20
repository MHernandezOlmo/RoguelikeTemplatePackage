namespace Core.Install.Ports
{
    public interface IReferencesRepository
    {
        void AddReference<T>(T reference);
        T GetReference<T>();
        bool HasReference<T>();
        bool RemoveReference<T>();
    }
}