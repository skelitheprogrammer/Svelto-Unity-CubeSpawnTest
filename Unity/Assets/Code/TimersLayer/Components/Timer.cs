using Svelto.ECS;

namespace Code.TimersLayer
{
    public struct Timer<T> : IEntityComponent
    {
        public float StartValue;
        public float Value;
    }
}