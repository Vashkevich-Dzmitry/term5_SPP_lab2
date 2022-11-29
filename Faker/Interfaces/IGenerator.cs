namespace Faker.Interfaces
{
    public interface IGenerator
    {
        public object Generate(Type type, IGeneratorContext context);
        public Type GetType();

    }
}