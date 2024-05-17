using System.Collections.Generic;
using Code.EngineViewSyncLayer.ViewSync;
using Svelto.DataStructures.Experimental;
using Svelto.ECS.ResourceManager;

namespace Code.EngineViewSyncLayer.Objects
{
    public class ViewHandlerResourceManager<T> : ECSResourceManager<T> where T : class
    {
        private readonly Dictionary<ValueIndex, IViewHandler<T>> _viewHandlerMap;

        public ViewHandlerResourceManager()
        {
            _viewHandlerMap = new();
        }

        public void RegisterHandler(ValueIndex valueIndex, IViewHandler<T> handler)
        {
            
            _viewHandlerMap.Add(valueIndex, handler);
        }

        public new IViewHandler<T> this[ValueIndex index] => _viewHandlerMap[index];
    }
}