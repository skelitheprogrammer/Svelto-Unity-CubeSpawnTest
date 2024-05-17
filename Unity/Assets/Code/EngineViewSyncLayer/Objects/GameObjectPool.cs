using Code.EngineViewSyncLayer.ViewSync;
using Svelto.DataStructures.Experimental;
using UnityEngine;

namespace Code.EngineViewSyncLayer.Objects
{

    public class GameObjectPool : ViewPool<GameObject>
    {
        public GameObjectPool(ValueIndex resourceIndex, IViewFactory<GameObject> factory, int allocationSize = 16) : base(resourceIndex, factory, allocationSize)
        {
        }

        protected override void OnRent(GameObject instance)
        {
            instance.SetActive(true);
        }

        protected override void OnRecycle(GameObject instance)
        {
            instance.SetActive(false);
        }
    }
}