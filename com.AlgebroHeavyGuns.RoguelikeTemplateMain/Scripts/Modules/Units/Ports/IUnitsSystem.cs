using System.Collections.Generic;

namespace Units.Ports
{
    public interface IUnitsSystem
    {
        bool TryGetUnit(int key, out IUnitModel unitModel);
        IEnumerable<IUnitModel> GetAllUnits();
    }
}