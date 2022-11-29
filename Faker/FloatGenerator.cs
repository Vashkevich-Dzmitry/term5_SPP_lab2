namespace Faker
{
    internal class FloatGenerator : IGenerator
    {
        public object Generate()
        {
            return (float)(new Random().NextDouble());
        }

        public Type GetGeneratorType()
        {
            return typeof(float);
        }
    }
}
