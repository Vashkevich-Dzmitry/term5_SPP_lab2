using Faker.Interfaces;

namespace Faker.Generators
{
    internal class BoolGenerator : IGenerator
    {
        public object Generate(Type type, IGeneratorContext context)
        {
            return new Random().NextInt64(1) == 1;
        }

        public bool CanGenerate(Type type)
        {
            return type == typeof(bool);
        }
    }
}
