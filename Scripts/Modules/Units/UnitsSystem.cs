using System.Collections.Generic;
using System.Linq;
using Units.Ports;

namespace Units
{
    public class UnitsSystem : IUnitsSystem
    {
        private Dictionary<int, UnitModel> unitModels;
        private IUnitStaticDataRepository unitStaticDataRepository;

        public void SetData(IUnitStaticDataRepository unitStaticDataRepository)
        {
            this.unitStaticDataRepository = unitStaticDataRepository;
        }

        public void Initialize()
        {
            unitModels = unitStaticDataRepository.GetElements().ToDictionary(
                x => x.Id, 
                x => new UnitModel(x));
        }

        public void Dispose()
        {
            unitModels.Clear();
            unitModels = null;
        }
        
        public IEnumerable<IUnitModel> GetAllUnits()
        {
            return unitModels.Values;
        }

        public bool TryGetUnit(int key, out IUnitModel unitModel)
        {
            unitModel = null;
            if(!unitModels.TryGetValue(key, out var model)) return false;
            unitModel = model;
            return true;
        }
    }
}


