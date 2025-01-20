using System.Collections.Generic;
using UnityEngine;

namespace Entities.Ports
{
    public interface IEntityFactory
    {
        T CreateEntity<T>(int id, Vector3 position, Quaternion rotation, object staticData)
            where T : IEntityController;

        T CreateEntity<T>(int id, EntityView view, object staticData) 
            where T : IEntityController;

        bool RemoveEntity(IEntityController entityController);
    }
}