using Units.Ports;

namespace Units
{
    public class UnitModel : IUnitModel
    {
        public IUnitStaticData StaticData { get; }

        public UnitModel(IUnitStaticData staticData)
        {
            StaticData = staticData;
        }
    }
}