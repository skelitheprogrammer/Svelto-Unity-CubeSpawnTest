using System.Collections.Generic;
using Svelto.DataStructures.Experimental;

namespace Code.EngineViewSyncLayer.Objects
{
    public class EntityInstanceManager<T> where T : class
    {
        private readonly SortedList<uint, T> _map;
        private readonly ViewHandlerResourceManager<T> _resourceManager;

        public EntityInstanceManager(ViewHandlerResourceManager<T> resourceManager)
        {
            _map = new SortedList<uint, T>();

            _resourceManager = resourceManager;
        }

        public void Add(uint entityId, ValueIndex resourceIndex)
        {
            T instance = _resourceManager[resourceIndex].Get();

            _map.Add(entityId, instance);
        }

        public void Remove(uint entityId, ValueIndex resourceIndex)
        {
            T instance = _map[entityId];
            _resourceManager[resourceIndex].Remove(instance);
            _map.Remove(entityId);
        }

        public T this[uint entityId] => _map[entityId];
    }
}