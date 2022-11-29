using Faker.Interfaces;

namespace Faker
{
    internal class Faker : IFaker
    {
        private readonly GeneratorsSystem _generatorsSystem;
        private readonly CycleResolveService _cycleResolveService;
        private readonly IGeneratorContext _context;

        public Faker()
        {
            _generatorsSystem = new GeneratorsSystem();
            _cycleResolveService = new CycleResolveService();
            _context = new GeneratorContext(new Random(), this);
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
                result = _generatorsSystem.Generate(t, _context);
            } else 

            return result;
        }
    }
}
