using System.Reflection;
using Faker.Interfaces;

namespace Faker.Generators
{
    public class ListGenerator : IGenerator
    {
        private const int maxListLength = 8;
        private const int minListLength = 4;
        public object Generate(Type type, IGeneratorContext context)
        {
            var genericType = type.GetGenericArguments().First();
            var genericList = typeof(List<>).MakeGenericType(genericType);
            MethodInfo fakerCreateMethod = typeof(Faker).GetMethod("Create")!.MakeGenericMethod(new Type[] { genericType });

            var list = Activator.CreateInstance(genericList);
            var listAddMethod = genericList.GetMethod("Add");

            int listLength = context.Random.Next(minListLength ,maxListLength);
            for (int i = 1; i < listLength; i++)
            {
                var randomList = fakerCreateMethod.Invoke(context.Faker, null);
                listAddMethod!.Invoke(list, new object[] { randomList! });
            }
            
            

            return list!;
        }

        public bool CanGenerate(Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>);
        }
    }
}
