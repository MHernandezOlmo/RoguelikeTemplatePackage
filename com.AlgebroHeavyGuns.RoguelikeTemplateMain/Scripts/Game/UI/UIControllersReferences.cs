using Core.Install;
using Core.Install.Ports;
using Game.Installer;

namespace Game.UI
{
    public class UIControllersReferences : IUIControllerReferences, IReferencesRepository
    {
        private ReferencesLocator controllerLocator => ReferencesLocator.Instance;

        public void AddReference<T>(T reference) => controllerLocator.AddReference(reference);
        public T GetReference<T>() => controllerLocator.GetReference<T>();

        public T GetController<T>() => controllerLocator.GetReference<T>();

        public bool HasReference<T>() => controllerLocator.HasReference<T>();
        public bool RemoveReference<T>() => controllerLocator.RemoveReference<T>();

        public void Clear() => controllerLocator.Clear();
    }
}