using Code.EngineViewSyncLayer.ViewSync;
using Svelto.DataStructures.Experimental;
using Svelto.ECS.ResourceManager;
using UnityEngine;

namespace Code.EngineViewSyncLayer.Objects
{
    public class GameObjectFactory : ViewFactory<GameObject>
    {
        public GameObjectFactory(ECSResourceManager<GameObject> resourceManager) : base(resourceManager)
        {
        }

        public override GameObject Create(ValueIndex resourceIndex)
        {
            GameObject resource = ResourceManager[resourceIndex];
            return Object.Instantiate(resource);
        }
    }
}