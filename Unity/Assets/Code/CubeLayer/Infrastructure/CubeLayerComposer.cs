using Code.CubeLayer.Engines;
using Code.UtilityLayer;
using Svelto.DataStructures;
using Svelto.ECS;

namespace Code.CubeLayer.Infrastructure
{
    public static class CubeLayerComposer
    {
        public static void Compose(EnginesRoot root, ITime time, FasterList<IStepEngine> orderedEngine)
        {
            MoveCubeEngine moveCubeEngine = new(time);
            FaceCubeDirectionEngine faceCubeDirectionEngine = new();
            
            orderedEngine.Add(moveCubeEngine);
            orderedEngine.Add(faceCubeDirectionEngine);

            root.AddEngine(moveCubeEngine);
            root.AddEngine(faceCubeDirectionEngine);
        }
    }
}