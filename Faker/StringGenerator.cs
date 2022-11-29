namespace Faker
{
    internal class StringGenerator : IGenerator
    {
        private const string validCharacters= "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        private const int maxStringLength = 16;
        private const int minStringLength = 4;

        public object Generate()
        {
            int stringLength = (int)new Random().NextInt64(minStringLength, maxStringLength);
            char[] str = new char[stringLength];

            for (int i = 0; i < stringLength; i++)
            {
                str[i] = validCharacters[new Random().Next(validCharacters.Length)];
            }
            return new string(str);
        }

        public Type GetGeneratorType()
        {
            return typeof(string);
        }
    }
}
