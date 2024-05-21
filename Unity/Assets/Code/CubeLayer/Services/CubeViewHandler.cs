using Code.EngineViewSyncLayer.Objects;
using Code.EngineViewSyncLayer.ViewSync;
using UnityEngine;

namespace Code.CubeLayer.Services
{
    public class CubeViewHandler : IViewHandler<GameObject>
    {
        private readonly GameObjectPool _pool;

        public CubeViewHandler(GameObjectPool pool)
        {
            _pool = pool;
        }

        public GameObject Get() => _pool.Rent();
        public void Remove(GameObject view) => _pool.Recycle(view);
    }
}