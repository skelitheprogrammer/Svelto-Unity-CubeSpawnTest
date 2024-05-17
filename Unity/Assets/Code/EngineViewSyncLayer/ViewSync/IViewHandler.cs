namespace Code.EngineViewSyncLayer.ViewSync
{
    /// <summary>
    /// Abstracts the way how to get the instance of a resource
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IViewHandler<T>
    {
        T Get();
        void Remove(T view);
    }
}