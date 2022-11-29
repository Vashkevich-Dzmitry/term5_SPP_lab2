using Faker.Interfaces;

namespace Faker
{
    public class GeneratorContext : IGeneratorContext
    {
        public string ValidCharacters { get; }
        public Random Random { get; }
        public IFaker Faker { get; }

        public GeneratorContext(Random random, IFaker faker)
        {
            Faker = faker;
            Random = random;
            ValidCharacters = "ABCDEFGHIGKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        }
    }
}
