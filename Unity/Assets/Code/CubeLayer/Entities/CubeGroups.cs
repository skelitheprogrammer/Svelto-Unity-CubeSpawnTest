using Code.DestroyableLayer.Infrastructure;
using Code.TransformLayer;
using Svelto.ECS;

namespace Code.CubeLayer.Entities
{
    public class Cube : GroupTag<Cube>
    {
    }

    public class SineWave : GroupTag<SineWave>
    {
    }

    public class WithTraveledDistance : GroupTag<WithTraveledDistance>
    {
    }

    public class CubesWithTraveledDistance : GroupCompound<Cube, WithTraveledDistance>
    {
    }

    public class TransformableCubes : GroupCompound<Cube, Transformable>
    {
    }

    public class SineWaveCubes : GroupCompound<Cube, SineWave, Transformable>
    {
    }

    public class DestroyedCubes : GroupCompound<Cube, Destroyed>
    {
    }

    public class AliveCubes : GroupCompound<Cube, Alive>
    {
    }
}