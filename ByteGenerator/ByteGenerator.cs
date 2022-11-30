using Faker.Interfaces;

namespace ByteGeneratorPlugin
{
    public class ByteGenerator : IGenerator
    {
        public object Generate(Type type, IGeneratorContext context)
        {
            return (byte)new Random().Next(byte.MaxValue);
        }

        public bool CanGenerate(Type type)
        {
            return type == typeof(byte);
        }
    }
}