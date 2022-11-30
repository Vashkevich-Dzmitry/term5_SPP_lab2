using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPP_lab2
{
    public class Bar
    {
        public bool flag;
        public Foo foo;

        private Bar(Foo foo)
        { this.foo = foo; }
    }
}
