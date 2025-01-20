using Core.Install.Base;
using Core.Install.Ports;
using Units;
using Units.Ports;

namespace Game.Installer.Modules
{
    public class UnitsModuleInstaller : ISystemInstaller
    {
        private readonly UnitsSystem unitsSystem = new();
        public void DefineReferences(IReferencesRepository referencesLocator)
        {
            referencesLocator.AddReference<IUnitsSystem>(unitsSystem);
        }

        public void Install(IReferencesRepository referencesLocator)
        {
            unitsSystem.SetData(referencesLocator.GetReference<IUnitStaticDataRepository>());
        }

        public void Uninstall(IReferencesRepository referencesLocator)
        {
            referencesLocator.RemoveReference<IUnitsSystem>();
        }

        public void Initialize()
        {
            unitsSystem.Initialize();
        }

        public void Dispose()
        {
            unitsSystem.Dispose();
        }

        public void Tick(float deltaTime)
        {
            //nothing
        }
    }
}