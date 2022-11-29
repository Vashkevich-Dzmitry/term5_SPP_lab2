namespace Faker.Generators
{
    public interface IGenerator
    {
        public object Generate();
        public Type GetType();

    }
}
