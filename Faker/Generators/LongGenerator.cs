namespace Faker.Generators
{
    internal class LongGenerator : IGenerator
    {
        public object Generate()
        {
            return new Random().NextInt64();
        }

        public Type GetGeneratorType()
        {
            return typeof(long);
        }
    }
}
