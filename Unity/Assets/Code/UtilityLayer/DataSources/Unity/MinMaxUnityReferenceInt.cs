using Code.Common.DataConfigSystem.ValueReference.MinMax;
using UnityEngine;

namespace Code.UtilityLayer.DataSources.Unity
{
    [System.Serializable]
    public class MinMaxUnityReferenceInt : MinMaxReferenceInt
    {
        public override int Reference => Random.Range(Min.Reference, Max.Reference);
    }
}