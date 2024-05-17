using Svelto.Common;
using Svelto.ECS;
using Svelto.ECS.Schedulers;

namespace Code.Ticking
{
    [Sequenced(nameof(TickEngineNames.SUBMISSION_ENGINE))]
    public class TickEngine : IStepEngine
    {
        private readonly EntitiesSubmissionScheduler _scheduler;
        public string name => nameof(TickEngineNames.SUBMISSION_ENGINE);

        public TickEngine(EntitiesSubmissionScheduler entitySubmissionScheduler)
        {
            _scheduler = entitySubmissionScheduler;
        }

        public void Step()
        {
            _scheduler.SubmitEntities();
        }
    }
}