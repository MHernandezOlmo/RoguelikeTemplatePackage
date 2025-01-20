namespace Game.Installer
{
    public interface IUIControllerReferences
    {
        T GetController<T>();
        bool HasReference<T>();
        
    }
}