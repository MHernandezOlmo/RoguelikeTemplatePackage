namespace Core.Install.Base
{
    public interface ISystemInstaller : IDependencyInstaller
    {
        void Initialize();
        void Dispose();
        void Tick(float deltaTime);
    }
}