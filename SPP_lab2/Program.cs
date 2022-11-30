namespace SPP_lab2
{
    public class Program
    {
        public static void Main()
        {
            var faker = new Faker.Faker();
            var result = faker.Create<Foo>();
            Console.WriteLine(result.bigNumber);
            Console.WriteLine(result.site);
            foreach(var item in result.usefullList)
                Console.WriteLine(item);
            Console.WriteLine(result.Name);
            Console.WriteLine(result.bar);
            Console.WriteLine(result.bar.flag);
            Console.WriteLine(result.bar.foo);
        }
    }
}