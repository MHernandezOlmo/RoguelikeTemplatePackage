using System.Collections.Generic;
using UnityEngine;

namespace Entities.Ports
{
    public interface IEntitiesSystem
    {
        T CreateEntity<T>(Vector3 position, Quaternion rotation, object staticData=null, int prefix=0) where T : IEntityController;
        T CreateEntityFromView<T>(EntityView view, object staticData = null, int prefix = 0) where T : IEntityController;
        bool TryGetEntity<T>(int id, out T entity) where T : IEntityController;
        bool TryGetEntityOfType<T>(out T entity) where T : IEntityController;
        IEnumerable<T> GetEntitiesOfType<T>() where T : IEntityController;
        bool RemoveEntity(int dataEntityId, bool removingView=true);
    }
}