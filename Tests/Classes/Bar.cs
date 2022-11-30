using System.Collections.Generic;

namespace FackerUnitTests
{
    public class Bar
    {
        public Foo _foo;
        public float e;
        public List<byte> _list;

        private Bar()
        {
            _list = new List<byte>() { 1, 2, 3};
        }
    }
}