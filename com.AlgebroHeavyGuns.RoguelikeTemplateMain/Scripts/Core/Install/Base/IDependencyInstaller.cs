using Core.Install.Ports;

namespace Core.Install.Base
{
    public interface IDependencyInstaller
    {
        void DefineReferences(IReferencesRepository referencesLocator);
        void Install(IReferencesRepository referencesLocator);
        void Uninstall(IReferencesRepository referencesLocator);
    }
}