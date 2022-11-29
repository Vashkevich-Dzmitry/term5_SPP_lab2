using Faker.Interfaces;
internal class FloatGenerator : IGenerator
{
    public object Generate(Type type, IGeneratorContext context)
    {
        return (float)(new Random().NextDouble());
    }

    public bool CanGenerate(Type type)
    {
        return type == typeof(float);
    }
}
