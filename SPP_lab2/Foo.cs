using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPP_lab2
{
    public class Foo
    {
        public long bigNumber { get; set; }
        public Uri site;
        public List<byte> usefullList;
        public string Name;
        public Bar bar;

        public Foo()
        {

        }

        public Foo(string name)
        {
            Name = name;
        }
    }
}

