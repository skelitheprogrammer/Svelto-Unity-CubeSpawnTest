namespace Code.UtilityLayer
{
    public static class EntityIdStorage
    {
        private static readonly IdStorage STORAGE = new();

        public static uint Get()
        {
            return STORAGE.Get();
        }

        public static void Return(uint id)
        {
            STORAGE.Return(id);
        }
    }
}