using System.Collections.Generic;

namespace Code.UtilityLayer
{
    public sealed class IdStorage
    {
        public Queue<uint> _ids;
        public uint Count;

        public IdStorage()
        {
            _ids = new();
        }

        public uint Get()
        {
            bool recycled = _ids.TryDequeue(out uint id);
            id = recycled ? id : Count++;

            return id;
        }

        public void Return(uint id)
        {
            _ids.Enqueue(id);
        }
    }
}