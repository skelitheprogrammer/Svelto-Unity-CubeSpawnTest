using Code.CubeLayer.Entities.Components;
using Code.CubeLayer.Infrastructure;
using Code.UtilityLayer;
using Svelto.Common;
using Svelto.ECS;

namespace Code.CubeLayer.Engines
{
    [Sequenced(nameof(CubeEngineNames.MOVE_CUBE_ENGINE))]
    public class MoveCubeEngine : IQueryingEntitiesEngine, IStepEngine
    {
        private readonly ITime _time;
        public EntitiesDB entitiesDB { get; set; }
        public string name => nameof(CubeEngineNames.MOVE_CUBE_ENGINE);

        public MoveCubeEngine(ITime time)
        {
            _time = time;
        }

        public void Ready()
        {
        }

        public void Step()
        {
            foreach ((var (positions, directions, moveSpeeds, count), ExclusiveGroupStruct _) in entitiesDB.QueryEntities<Position, Direction, MoveSpeed>(MovableCubes.Groups))
            {
                for (int i = 0; i < count; i++)
                {
                    ref Position position = ref positions[i];
                    ref Direction direction = ref directions[i];
                    ref MoveSpeed moveSpeed = ref moveSpeeds[i];

                    position.Value += direction.Value * (moveSpeed.Value * _time.DeltaTime);
                }
            }
        }
    }
}