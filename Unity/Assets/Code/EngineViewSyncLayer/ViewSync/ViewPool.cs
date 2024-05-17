using System.Collections.Generic;
using Svelto.DataStructures.Experimental;

namespace Code.EngineViewSyncLayer.ViewSync
{
    public abstract class ViewPool<T> : IViewPool<T>
    {
        private const int ALLOCATION_SIZE_DEFAULT = 16;

        private readonly IViewFactory<T> _factory;
        private readonly Queue<T> _pool;
        private readonly ValueIndex _resourceIndex;
        private readonly int _allocationSize;

        protected ViewPool(ValueIndex resourceIndex, IViewFactory<T> factory, int allocationSize = ALLOCATION_SIZE_DEFAULT)
        {
            _resourceIndex = resourceIndex;
            _factory = factory;
            _allocationSize = allocationSize;
            _pool = new();
        }

        public void Allocate(int size)
        {
            for (int i = 0; i < size; i++)
            {
                T instance = _factory.Create(_resourceIndex);
                Recycle(instance);
            }
        }

        public T Rent()
        {
            if (_pool.Count == 0)
            {
                Allocate(_allocationSize);
            }

            return Get();
        }

        private T Get()
        {
            T instance = _pool.Dequeue();
            OnRent(instance);
            return instance;
        }

        public void Recycle(T instance)
        {
            _pool.Enqueue(instance);
            OnRecycle(instance);
        }

        protected abstract void OnRent(T instance);
        protected abstract void OnRecycle(T instance);
    }
}