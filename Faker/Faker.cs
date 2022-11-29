namespace Faker
{
    internal class Faker
    {
        private CycleResolveService _cycleResolveService;

        public T Create<T>()
        {
            var type = typeof(T);
            return (T)Create(type);
        }

        private object Create(Type t)
        {

        }
    }
}
