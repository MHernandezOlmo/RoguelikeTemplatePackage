using System.Collections.Generic;
using System.Linq;
using Entities.Ports;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Entities
{
        public class EntitiesSystem : IEntitiesSystem
    {
        private IEntityFactory entityFactory;
        
        private Dictionary<int, IEntityController> entities;

        private const int MAX_ENTITIES = 99999;

        public void SetData(IEntityFactory entityFactory)
        {
            this.entityFactory = entityFactory;
        }
        
        public void Initialize()
        {
            entities = new Dictionary<int, IEntityController>();
        }

        public void Dispose()
        {
            entities.Clear();
            entities = null;
        }

        public T CreateEntity<T>(Vector3 position, Quaternion rotation, object staticData, int prefix) where T : IEntityController
        {
            var id = GenerateUniqueRandomID(prefix);
            var entity = entityFactory.CreateEntity<T>(id, position, rotation, staticData);
            entities.Add(id, entity);
            return entity;
        }

        public T CreateEntityFromView<T>(EntityView view, object staticData, int prefix) where T : IEntityController
        {
            var id = GenerateUniqueRandomID(prefix);
            var entity = entityFactory.CreateEntity<T>(id, view, staticData);
            entities.Add(id, entity);
            return entity;
        }

        public bool TryGetEntity<T>(int id, out T entity) where T : IEntityController
        {
            var type = typeof(T);
            if (!entities.TryGetValue(id, out var innerEntity))
            {
                Debug.LogError($"Entity with id={id} not found.");
                entity = default(T);
                return false;
            }

            if (innerEntity is T castedEntity)
            {
                entity = castedEntity;
                return true;
            }

            Debug.LogError($"Entity with id={id} is not of type {type}");
            entity = default(T);
            return false;
        }

        public bool TryGetEntityOfType<T>(out T entity) where T : IEntityController
        {
            var foundEntity = entities.Values.FirstOrDefault(x => x is T);
            if (foundEntity == default)
            {
                entity = default;
                return false;
            }

            entity = (T)foundEntity;
            return true;
        }


        public IEnumerable<T> GetEntitiesOfType<T>() where T : IEntityController
        {
            return entities.Values.Where(entity => entity is T).Cast<T>();
        }
        
        
        public bool RemoveEntity(int id, bool removingView)
        {
            if (!entities.Remove(id, out var entityController))
            {
                Debug.LogError("Not found " + id + " entity. Removing failed.");
                return false;
            }

            if(removingView) return entityFactory.RemoveEntity(entityController);
            
            return true;
        }
        

        private int GenerateUniqueRandomID(int prefix=0)
        {
            var idWithPrefix = (prefix) * (MAX_ENTITIES + 1);
            var nextId = 0;
            do
            {
                var randomValue = Random.Range(0, MAX_ENTITIES);
                nextId = idWithPrefix + randomValue;
            } while (entities.ContainsKey(nextId));

            return nextId;
        }

        public void Tick(float deltaTime)
        {
            foreach (var entityController in entities.Values)
            {
                entityController.Tick(deltaTime);
            }
        }
    }
}
