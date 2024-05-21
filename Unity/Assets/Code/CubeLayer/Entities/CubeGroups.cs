using Code.DestroyableLayer.Infrastructure;
using Code.TransformLayer;
using Svelto.ECS;

namespace Code.CubeLayer.Entities
{
    public class Cube : GroupTag<Cube>
    {
    }

    public class SineMovement : GroupTag<SineMovement>
    {
    }

    public class StraightLineCubes : GroupCompound<Cube, Transformable>
    {
    }

    public class SineWaveDirectionMovementCubes : GroupCompound<Cube, SineMovement, Transformable>
    {
    }

    public class DestroyedCubes : GroupCompound<Cube, Destroyed>
    {
    }

    public class AliveCubes : GroupCompound<Cube, Alive>
    {
    }

    public class WithTraveledDistance : GroupTag<WithTraveledDistance>
    {
    }

    public class CubesWithTraveledDistance : GroupCompound<Cube, WithTraveledDistance>
    {
    }
}