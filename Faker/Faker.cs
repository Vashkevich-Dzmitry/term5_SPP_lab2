namespace Faker
{
    internal class Faker
    {
        private readonly GeneratorsSystem _generatorsSystem;
        private readonly CycleResolveService _cycleResolveService;

        public Faker()
        {
            _generatorsSystem = new GeneratorsSystem();
            _cycleResolveService = new CycleResolveService();
        }
        public T Create<T>()
        {
            var type = typeof(T);
            return (T)Create(type);
        }

        private object Create(Type t)
        {
            object result;
            if (_generatorsSystem.GeneratorExists(t))
            {
                result = _generatorsSystem.Generate(t);
            } else 

            return result;
        }
    }
}
