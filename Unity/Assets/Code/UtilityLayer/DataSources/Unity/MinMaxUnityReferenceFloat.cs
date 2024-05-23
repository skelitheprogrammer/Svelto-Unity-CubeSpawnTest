using Code.Common.DataConfigSystem.ValueReference.MinMax;
using UnityEngine;

namespace Code.UtilityLayer.DataSources.Unity
{
    [System.Serializable]
    public class MinMaxUnityReferenceFloat : MinMaxReferenceFloat
    {
        public override float Reference => Random.Range(Min.Reference, Max.Reference);
    }
}