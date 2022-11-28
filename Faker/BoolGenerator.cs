using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker
{
    internal class BoolGenerator : IGenerator
    {
        public object Generate()
        {
            return new Random().NextInt64(1) == 1;
        }

        public Type GetGeneratorType()
        {
            return typeof(bool);
        }
    }
}
