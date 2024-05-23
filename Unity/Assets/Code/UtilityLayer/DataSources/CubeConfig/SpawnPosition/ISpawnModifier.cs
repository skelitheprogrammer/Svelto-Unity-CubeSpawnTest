using UnityEngine;

namespace Code.UtilityLayer.DataSources.CubeConfig
{
    public interface ISpawnModifier
    {
        void Apply(ref Vector3 position);
    }
}