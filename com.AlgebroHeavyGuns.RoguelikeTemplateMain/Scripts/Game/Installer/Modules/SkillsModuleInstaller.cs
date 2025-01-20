using Core.Install.Base;
using Core.Install.Ports;
using Skills;
using Skills.Ports;
using Units.Ports;

namespace Game.Installer.Modules
{
    public class SkillsModuleInstaller : ISystemInstaller
    {
        private readonly SkillsSystem skillsSystem = new();
        public void DefineReferences(IReferencesRepository referencesLocator)
        {
            referencesLocator.AddReference<ISkillsSystem>(skillsSystem);
        }

        public void Install(IReferencesRepository referencesLocator)
        {
            skillsSystem.SetData(referencesLocator.GetReference<ISkillStaticDataRepository>());
        }

        public void Uninstall(IReferencesRepository referencesLocator)
        {
            referencesLocator.RemoveReference<IUnitsSystem>();
        }

        public void Initialize()
        {
            skillsSystem.Initialize();
        }

        public void Dispose()
        {
            skillsSystem.Dispose();
        }

        public void Tick(float deltaTime)
        {
            //nothing
        }
    }
}