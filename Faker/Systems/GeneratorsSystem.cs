using Faker.Interfaces;
using Faker.Generators;
namespace Faker
{
    internal class GeneratorsSystem
    {
        private readonly Dictionary<Type, IGenerator> _generators = new();
        public GeneratorsSystem()
        {
            _generators.Add(typeof(string), new StringGenerator());
            _generators.Add(typeof(Uri), new UriGenerator());
            _generators.Add(typeof(long), new LongGenerator());
            _generators.Add(typeof(bool), new BoolGenerator());

            ConnectDll();
        }
        private void ConnectDll()
        {
            
        }

        public object Generate(Type type, IGeneratorContext context)
        {
            return _generators[type].Generate(type, context);
        }

        public bool GeneratorExists(Type type)
        {
            return _generators.ContainsKey(type);
        }
    }
}
