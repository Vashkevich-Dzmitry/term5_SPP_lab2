using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
