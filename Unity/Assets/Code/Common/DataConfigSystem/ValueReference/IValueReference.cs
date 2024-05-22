using UnityEngine;

namespace Code.Common.DataConfigSystem.ValueReference
{
    public interface IValueReference<T> where T : unmanaged
    {
        T Reference { get; }
    }


    public interface IValueReferenceFloat : IValueReference<float>
    {
    }


    public interface IValueReferenceVector3 : IValueReference<Vector3>
    {
    }

    public interface IValueReferenceInt : IValueReference<int>
    {
    }
}