using UnityEngine;

namespace Code.UtilityLayer
{
    public class UnityTime : ITime
    {
        public float DeltaTime => Time.deltaTime;
    }
}