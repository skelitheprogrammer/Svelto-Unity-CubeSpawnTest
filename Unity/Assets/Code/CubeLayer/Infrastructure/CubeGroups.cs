using Code.TransformLayer;
using Svelto.ECS;

namespace Code.CubeLayer.Infrastructure
{
    public class Cube : GroupTag<Cube>
    {
    }

    public class TransformableCubes : GroupCompound<Cube, Transformable>
    {
    }
}