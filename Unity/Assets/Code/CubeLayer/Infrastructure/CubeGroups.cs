using Code.DestroyableLayer.Infrastructure;
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

    public class AliveCubes : GroupCompound<Cube, Alive, Transformable>
    {
    }

    public class DestroyedCubes : GroupCompound<Cube, Destroyed>
    {
    }
}