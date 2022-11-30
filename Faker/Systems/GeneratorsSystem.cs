using Faker.Interfaces;
using Faker.Generators;
using System.Reflection;

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
            _generators.Add(new ListGenerator());

            ConnectDll();
        }
        private void ConnectDll()
        {
            string pathToDll = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\..\\..\\Plugins\\");
            string[] allDll = Directory.GetFiles(pathToDll, "*.dll");
            foreach (string dllPath in allDll)
            {
                Assembly asm = Assembly.LoadFrom(dllPath);
                foreach (Type type in asm.GetExportedTypes())
                {
                    if (type.IsClass && typeof(IGenerator).IsAssignableFrom(type))
                    {
                        IGenerator g = (IGenerator)Activator.CreateInstance(type);
                        _generators.Add(g);
                    }
                }
            }
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
