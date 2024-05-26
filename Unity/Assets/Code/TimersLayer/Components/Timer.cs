using Svelto.ECS;

namespace Code.TimersLayer.Components
{
    public struct Timer<T> : IEntityComponent
    {
        public float StartValue;
        public float Value;
    }
}