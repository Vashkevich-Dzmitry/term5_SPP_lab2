using Microsoft.VisualStudio.TestTools.UnitTesting;
using Faker;

namespace FackerUnitTests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void FakerCanGenerateSimpleTypes()
        {
            Faker.Faker faker = new();
            var foo = faker.Create<Foo>();

            Assert.IsTrue(foo.name != "");
            Assert.IsTrue(foo.GetId() != 0);
            Assert.IsTrue(foo.bar.e != 0);
        }

        [TestMethod]
        public void FakerCanGenerateList()
        {
            Faker.Faker faker = new();
            var foo = faker.Create<Foo>();

            Assert.IsTrue(foo.bar._list.Count > 0);
            Assert.IsTrue(foo.bar._list![0] > 0);

        }

        [TestMethod]
        public void FakerCanGenerateObjectWithPrivateConstractor()
        {
            Faker.Faker faker = new();
            var foo = faker.Create<Foo>();

            Assert.IsTrue(foo.bar != null);
        }

        [TestMethod]
        public void FakerIgnoreCycles()
        {
            Faker.Faker faker = new();
            var foo = faker.Create<Foo>();


            Assert.IsTrue(foo.bar != null);
            Assert.IsTrue(foo.bar._foo == null);
        }

        [TestMethod]
        public void FakerCanCreateUri()
        {
            Faker.Faker faker = new();
            var foo = faker.Create<Foo>();

            Assert.IsTrue(foo.uri.ToString() != "");
        }
    }
}