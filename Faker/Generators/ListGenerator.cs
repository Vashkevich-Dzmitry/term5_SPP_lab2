using System.Reflection;
using Faker.Interfaces;

namespace Faker.Generators
{
    internal class ListGenerator : IGenerator
    {
        public object Generate(Type type, IGeneratorContext context)
        {
            var genericType = type.GetGenericArguments().First();
            var genericList = typeof(List<>).MakeGenericType(genericType);
            MethodInfo fakerCreateMethod = typeof(Faker).GetMethod("Create")!.MakeGenericMethod(new Type[] { genericType });
            var randomList = fakerCreateMethod.Invoke(context.Faker, null);

            var list = Activator.CreateInstance(genericList);
            var listAddMethod = genericList.GetMethod("Add");
            listAddMethod!.Invoke(list, new object[] { randomList! });

            return list!;
        }

        public Type GetGeneratorType()
        {
            return typeof(List<>);
        }
    }
}
