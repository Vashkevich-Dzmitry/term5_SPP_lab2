using Faker.Generators;
internal class ByteGenerator : IGenerator
{
    public object Generate()
    {
        return new Random().Next(byte.MaxValue);
    }

    public Type GetGeneratorType()
    {
        return typeof(byte);
    }
}
