using Svelto.ECS;
using Svelto.ECS.Internal;

namespace Code.CubeLayer
{
    public static class EntityInitializerExtensions
    {
        public static ref EntityInitializer InitChained<T>(this ref EntityInitializer initializer, T component) where T : struct, _IInternalEntityComponent
        {
            initializer.Init(component);
            return ref initializer;
        }
    }
}