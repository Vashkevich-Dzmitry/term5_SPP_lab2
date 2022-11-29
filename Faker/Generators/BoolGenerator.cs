namespace Faker.Generators
{
    internal class BoolGenerator : IGenerator
    {
        public object Generate()
        {
            return new Random().NextInt64(1) == 1;
        }

        public Type GetGeneratorType()
        {
            return typeof(bool);
        }
    }
}
