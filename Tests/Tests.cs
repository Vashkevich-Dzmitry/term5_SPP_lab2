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
            Faker.Faker faker = new Faker.Faker();
            var foo = faker.Create<Foo>();

            Assert.IsTrue(foo.name != "");
            Assert.IsTrue(foo.GetId() != 0);
            Assert.IsTrue(foo.bar.e != 0);
        }

        [TestMethod]
        public void FakerCanGenerateList()
        {
            Faker.Faker faker = new Faker.Faker();
            var foo = faker.Create<Foo>();

            Assert.IsTrue(foo.bar._list.Count > 0);
            Assert.IsTrue(foo.bar._list![0] > 0);

        }

        [TestMethod]
        public void TestMethod3()
        {
        }

        [TestMethod]
        public void TestMethod4()
        {
        }

        [TestMethod]
        public void TestMethod5()
        {
        }
    }
}