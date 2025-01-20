using Core.Install;
using Core.Install.Base;
using Core.Install.Ports;

namespace Game.Installer.Modules
{
    public class GameModulesInstaller : ISystemInstaller
    {
        private readonly ISystemInstaller[] modules =
        { new EntitiesModuleInstaller(), new StatisticsModuleInstaller(), new UnitsModuleInstaller(),
            new MapsModuleInstaller(), new ItemsModuleInstaller(), new InventoryModuleInstaller(),
            new UserModuleInstaller(), new BattleModuleInstaller(), new SimulationModuleInstaller(),
            new SkillsModuleInstaller(),
            new SaveModuleInstaller()
        };
        
        public void DefineReferences(IReferencesRepository referencesLocator)
        {
            foreach (var moduleInstaller in modules)
            {
                moduleInstaller.DefineReferences(ReferencesLocator.Instance);
            }
        }

        public void Install(IReferencesRepository referencesLocator)
        {
            foreach (var moduleInstaller in modules)
            {
                moduleInstaller.Install(ReferencesLocator.Instance);
            }
        }

        public void Uninstall(IReferencesRepository referencesLocator)
        {
            foreach (var moduleInstaller in modules)
            {
                moduleInstaller.Uninstall(ReferencesLocator.Instance);
            }
        }

        public void Initialize()
        {
            foreach (var moduleInstaller in modules)
            {
                moduleInstaller.Initialize();
            }
        }

        public void Dispose()
        {
            foreach (var moduleInstaller in modules)
            {
                moduleInstaller.Dispose();
            }
        }

        public void Tick(float deltaTime)
        {
            foreach (var moduleInstaller in modules)
            {
                moduleInstaller.Tick(deltaTime);
            }
        }
    }
}