using Svelto.DataStructures.Experimental;
using Svelto.ECS.ResourceManager;

namespace Code.EngineViewSyncLayer.ViewSync
{
    public abstract class ViewFactory<T> : IViewFactory<T> where T : class
    {
        protected readonly ECSResourceManager<T> ResourceManager;

        protected ViewFactory(ECSResourceManager<T> resourceManager)
        {
            ResourceManager = resourceManager;
        }

        public abstract T Create(ValueIndex resourceIndex);
    }
}