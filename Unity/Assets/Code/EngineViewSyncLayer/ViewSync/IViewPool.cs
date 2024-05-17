namespace Code.EngineViewSyncLayer.ViewSync
{
    public interface IViewPool<T>
    {
        T Rent();
        void Recycle(T instance);
    }
}