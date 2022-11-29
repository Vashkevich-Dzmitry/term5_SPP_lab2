using Faker.Interfaces;
using Faker.Generators;
namespace Faker
{
    internal class GeneratorsSystem
    {
        private readonly List<IGenerator> _generators = new();
        public GeneratorsSystem()
        {
            _generators.Add(new StringGenerator());
            _generators.Add(new UriGenerator());
            _generators.Add(new LongGenerator());
            _generators.Add(new BoolGenerator());

            ConnectDll();
        }
        private void ConnectDll()
        {

        }

        public object Generate(Type type, IGeneratorContext context)
        {
            IGenerator generator = (from _generator in _generators where _generator.CanGenerate(type) select _generator).First();
            return generator.Generate(type, context);
        }

        public bool GeneratorExists(Type type)
        {
            return (from _generator in _generators where _generator.CanGenerate(type) select _generator).Any();
        }
    }
}
