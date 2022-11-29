using System.Reflection;
using Faker.Interfaces;

namespace Faker.Generators
{
    internal class ListGenerator : IGenerator
    {
        public object Generate(Type type, IGeneratorContext context)
        {
            var argument = type.GetGenericArguments().First();
            var generic = typeof(List<>).MakeGenericType(argument);
            MethodInfo method = typeof(Faker).GetMethod("Create")!.MakeGenericMethod(new Type[] { argument });
            var result = method.Invoke(context.Faker, null);

            var list = Activator.CreateInstance(generic);
            var addMethod = generic.GetMethod("Add");
            addMethod!.Invoke(list, new object[] { result! });
            return list!;
        }

        public Type GetGeneratorType()
        {
            return typeof(List<>);
        }
    }
}
