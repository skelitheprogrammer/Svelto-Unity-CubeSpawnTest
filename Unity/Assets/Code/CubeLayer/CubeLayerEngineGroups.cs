using Svelto.Common;
using Svelto.DataStructures;
using Svelto.ECS;

namespace Code.CubeLayer
{
    [Sequenced(nameof(CubeEngineNames.UNSORTED))]
    public class CubeLayerUnsortedTickEngineGroup : UnsortedEnginesGroup<IStepEngine>
    {
        public CubeLayerUnsortedTickEngineGroup(FasterList<IStepEngine> engines) : base(engines)
        {
        }
    }


    [Sequenced(nameof(CubeEngineNames.STARTUP))]
    public class CubeLayerStartupGroup : UnsortedEnginesGroup<IStepEngine>
    {
        public CubeLayerStartupGroup(FasterList<IStepEngine> engines) : base(engines)
        {
        }
    }
}