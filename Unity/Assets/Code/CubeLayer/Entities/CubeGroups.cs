using Code.DestroyableLayer.Infrastructure;
using Svelto.ECS;

namespace Code.CubeLayer.Entities
{
    public class Cube : GroupTag<Cube>
    {
    }
    
    
    public class AliveCubes : GroupCompound<Cube, Alive>
    {
    }
    
    public class DestroyedCubes : GroupCompound<Cube, Destroyed>
    {
    }
    
    public class WithTraveledDistance : GroupTag<WithTraveledDistance>
    {
    }

    public class CubesWithTraveledDistance : GroupCompound<Cube, WithTraveledDistance>
    {
    }
}