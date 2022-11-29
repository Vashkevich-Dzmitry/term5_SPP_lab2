using Faker.Interfaces;

namespace Faker.Generators
{
    internal class StringGenerator : IGenerator
    {
        private const int maxStringLength = 16;
        private const int minStringLength = 4;

        public object Generate(Type type, IGeneratorContext context)
        {
            int stringLength = (int)new Random().NextInt64(minStringLength, maxStringLength);
            char[] str = new char[stringLength];

            for (int i = 0; i < stringLength; i++)
            {
                str[i] = context.ValidCharacters[new Random().Next(context.ValidCharacters.Length)];
            }
            return new string(str);
        }

        public Type GetGeneratorType()
        {
            return typeof(string);
        }
    }
}
