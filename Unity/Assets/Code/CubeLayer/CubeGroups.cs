using Code.DestroyableLayer.Infrastructure;
using Svelto.ECS;

namespace Code.CubeLayer
{
    public class Cube : GroupTag<Cube>
    {
    }
    
    public class AliveCubes : GroupCompound<Cube, Alive>
    {
    }
    
    public class DeadCubes : GroupCompound<Cube, Dead>
    {
    }
    
}