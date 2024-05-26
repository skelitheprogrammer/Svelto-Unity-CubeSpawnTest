using System;
using Code.CubeLayer.Entities;
using Code.DestroyableLayer.Infrastructure;
using Code.TimersLayer.Components;
using Svelto.ECS;
using UnityEngine;

namespace Code.TimersLayer.Engines
{
    public abstract class AddToExpiredTimerEngine<T> : IQueryingEntitiesEngine, IStepEngine
    {
        public void Ready()
        {
            _filters = entitiesDB.GetFilters();
        }

        public EntitiesDB entitiesDB { get; set; }
        private EntitiesDB.SveltoFilters _filters;

        protected abstract Predicate<ExclusiveGroupStruct> ConditionGroup { get; }

        public void Step()
        {
            var groups = entitiesDB.FindGroups<Timer<T>>();
            var filter = _filters.GetTransientFilter<Timer<T>>(TimerFilters.ExpiredTimer);

            foreach (((var timers, var ids, int count), ExclusiveGroupStruct group) in entitiesDB.QueryEntities<Timer<T>>(groups))
            {
                if (ConditionGroup(group))
                {
                    continue;
                }

                for (int i = 0; i < count; i++)
                {
                    if (timers[i].Value > 0)
                    {
                        continue;
                    }

                    timers[i].Value = 0;
                    filter.Add(new(ids[i], group), ids[i]);
                    Debug.Log("Added to expired");
                }
            }
        }

        public abstract string name { get; }
    }
}