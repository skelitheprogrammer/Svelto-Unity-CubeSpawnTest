using UnityEngine;

namespace Code.Common.DataConfigSystem.ValueReference
{
    public interface IValueReference<out T> where T : unmanaged
    {
        T Reference { get; }
    }

    public interface IValueReferenceFloat : IValueReference<float>
    {
    }

    public interface IValueReferenceInt : IValueReference<int>
    {
    }

    public interface IValueReferenceVector3 : IValueReference<Vector3>
    {
    }
}