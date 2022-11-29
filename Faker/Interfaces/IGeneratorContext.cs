namespace Faker.Interfaces
{
    public interface IGeneratorContext
    {
        string ValidCharacters { get; }
        Random Random { get; }
        IFaker Faker { get; }
    }
}
