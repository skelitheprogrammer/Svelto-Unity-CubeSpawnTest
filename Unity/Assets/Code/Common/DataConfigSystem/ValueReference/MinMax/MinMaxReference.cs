namespace Code.Common.DataConfigSystem.ValueReference.MinMax
{
    public abstract class MinMaxReference<T> : IValueReference<T> where T : unmanaged
    {
        public abstract IValueReference<T> Min { get; }
        public abstract IValueReference<T> Max { get; }

        public abstract T Reference { get; }
    }
}