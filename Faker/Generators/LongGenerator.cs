using Faker.Interfaces;

namespace Faker.Generators
{
    internal class LongGenerator : IGenerator
    {
        public object Generate(Type type, IGeneratorContext context)
        {
            return new Random().NextInt64();
        }

        public Type GetGeneratorType()
        {
            return typeof(long);
        }
    }
}
