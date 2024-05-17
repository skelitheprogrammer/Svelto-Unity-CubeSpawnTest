using Code.CubeLayer.DestroyableLayer.Infrastructure;
using Svelto.ECS;

namespace Code.CubeLayer.Infrastructure
{
    public class Cube : GroupTag<Cube>
    {
    }

    public class Movable : GroupTag<Movable>
    {
    }

    public class MovableCubes : GroupCompound<Cube, Movable>
    {
    }


    public class DestroyedCubes : GroupCompound<Cube, Destroyed>
    {
    }
}