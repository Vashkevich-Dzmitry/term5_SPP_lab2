namespace Faker
{
    public class CycleResolveService
    {
        private readonly List<Type> _types = new();
        public void Add(Type t)
        {
            _types.Add(t);
        }

        public void Remove(Type t)
        {
            _types.Remove(t);
        }

        public bool Contains(Type t)
        {
            return _types.Contains(t);
        }

        public void Clear()
        {
            _types.Clear();
        }
    }
}
