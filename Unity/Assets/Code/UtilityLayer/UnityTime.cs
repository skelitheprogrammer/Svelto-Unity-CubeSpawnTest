namespace Code.UtilityLayer
{
    public class UnityTime : ITime
    {
        public float DeltaTime => UnityEngine.Time.deltaTime;
        public float Time => UnityEngine.Time.time;
    }
}