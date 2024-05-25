﻿using System;
using System.Linq;
using Code.CubeLayer.Entities.Components;
using Svelto.ECS;

namespace Code.UtilityLayer.DataSources.CubeConfig.Attributes.Destroy
{
    public static class DestroyEntityAttributeExtensions
    {
        public static void ApplyToDescriptor<T>(this DestroyEntityAttribute attribute, ref DynamicEntityDescriptor<T> descriptor) where T : IEntityDescriptor, new()
        {
            foreach (DestroyEntityAttribute.IDestroyCondition condition in attribute.Conditions.Distinct())
            {
                switch (condition)
                {
                    case DestroyEntityAttribute.DistanceReachCondition:
                        descriptor.ExtendWith(new IComponentBuilder[]
                        {
                            new ComponentBuilder<DestroyDistance>(),
                            new ComponentBuilder<DistanceTraveled>()
                        });
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(condition));
                }
            }
        }

        public static void ApplyToInitializer(this DestroyEntityAttribute attribute, ref EntityInitializer entityInitializer)
        {
            foreach (ICondition condition in attribute.Conditions.Distinct())
            {
                switch (condition)
                {
                    case DestroyEntityAttribute.DistanceReachCondition distanceReachCondition:
                        entityInitializer.Init(new DestroyDistance
                        {
                            Value = distanceReachCondition.DestroyDistance.Reference
                        });
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(condition));
                }
            }
        }
    }
}