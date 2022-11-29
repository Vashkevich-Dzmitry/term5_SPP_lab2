using Faker.Interfaces;
internal class ByteGenerator : IGenerator
{
    public object Generate(Type type, IGeneratorContext context)
    {
        return new Random().Next(byte.MaxValue);
    }

    public bool CanGenerate(Type type)
    {
        return type == typeof(byte);
    }
}
