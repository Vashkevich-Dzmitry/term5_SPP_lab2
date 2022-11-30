using System;

namespace FackerUnitTests
{
    public class Foo
    {
        private long _id;
        public Uri uri;
        public Bar bar;
        public string name;

        public Foo()
        {
            _id = 1;
        }

        public long GetId()
        {
            return _id;
        }
    }
}