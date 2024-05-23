using System;
using Code.Common.DataConfigSystem.ValueReference;
using UnityEngine;

namespace Code.UtilityLayer.DataSources.CubeConfig
{
    [Serializable]
    public class Shift : ISpawnModifier
    {
        public Vector3 Axis;
        [SerializeReference, SubclassSelector] public IValueReferenceFloat Amount;

        public void Apply(ref Vector3 position)
        {
            position += Axis * Amount.Reference;
        }
    }
}