using Code.Common.DataConfigSystem.ValueReference;
using UnityEngine;

namespace Code.Common.DataConfigSystem
{
    public abstract class CubeSpawnPositionType
    {
        public abstract Vector3 Apply();
    }
    
    [System.Serializable]
    public class AroundSphereSpawnPositionType : CubeSpawnPositionType
    {
        [SerializeReference, SubclassSelector] public IValueReferenceFloat ValueModifier;

        public override Vector3 Apply()
        {
            return ValueModifier is null
                ? Random.onUnitSphere
                : Random.onUnitSphere * ValueModifier.Reference;
        }
    }
}