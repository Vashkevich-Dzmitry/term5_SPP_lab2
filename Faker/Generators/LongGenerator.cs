﻿using Faker.Interfaces;

namespace Faker.Generators
{
    internal class LongGenerator : IGenerator
    {
        public object Generate(Type type, IGeneratorContext context)
        {
            return new Random().NextInt64();
        }

        public bool CanGenerate(Type type)
        {
            return type == typeof(long);
        }
    }
}
