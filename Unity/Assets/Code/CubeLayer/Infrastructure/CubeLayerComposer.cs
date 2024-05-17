using Code.CubeLayer.Engines;
using Code.UtilityLayer;
using Svelto.DataStructures;
using Svelto.ECS;

namespace Code.CubeLayer.Infrastructure
{
    public static class CubeLayerComposer
    {
        public static void Compose(EnginesRoot root, ITime time, FasterList<IStepEngine> orderedEngine, IEntityFunctions functions)
        {
            MoveCubeEngine moveCubeEngine = new(time);
            FaceCubeDirectionEngine faceCubeDirectionEngine = new();
            CalculateDistanceTraveledEngine calculateDistanceTraveledEngine = new();
            DestroyOnDistanceTraveled destroyOnDistanceTraveled = new(functions);

            orderedEngine.Add(moveCubeEngine);
            orderedEngine.Add(faceCubeDirectionEngine);
            orderedEngine.Add(calculateDistanceTraveledEngine);
            orderedEngine.Add(destroyOnDistanceTraveled);

            root.AddEngine(moveCubeEngine);
            root.AddEngine(faceCubeDirectionEngine);
            root.AddEngine(calculateDistanceTraveledEngine);
            root.AddEngine(destroyOnDistanceTraveled);
        }
    }
}