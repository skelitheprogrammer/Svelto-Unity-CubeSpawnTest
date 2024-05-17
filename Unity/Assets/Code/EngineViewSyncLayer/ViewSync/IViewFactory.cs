using Svelto.DataStructures.Experimental;

namespace Code.EngineViewSyncLayer.ViewSync
{
    public interface IViewFactory<out T>
    {
        T Create(ValueIndex resourceIndex);
    }
}