using Faker.Interfaces;
using System.Reflection;
namespace Faker
{
    public class Faker : IFaker
    {
        private readonly GeneratorsSystem _generatorsSystem;
        private readonly CycleResolveService _cycleResolveService;
        private readonly IGeneratorContext _context;

        public Faker()
        {
            _generatorsSystem = new GeneratorsSystem();
            _cycleResolveService = new CycleResolveService();
            _context = new GeneratorContext(new Random(), this);
        }
        public T Create<T>()
        {
            var type = typeof(T);
            return (T)Create(type);
        }

        private object Create(Type t)
        {
            object result;
            if (_generatorsSystem.GeneratorExists(t))
            {
                result = _generatorsSystem.Generate(t, _context);
            }
            else
            {
                if (_cycleResolveService.Contains(t))
                {
                    result = null;
                }
                else
                {
                    _cycleResolveService.Add(t);
                    result = CreateObject(t);
                    FillFieldsAndProperties(result);
                    _cycleResolveService.Remove(t);
                }
            }

            return result;
        }

        private object CreateObject(Type type)
        {
            try
            {
                var constructor = Constructor(type.GetConstructors(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance));
                var constructorParameters = constructor.GetParameters();
                List<object> parameters = new();

                if (constructorParameters.Any())
                {
                    foreach (var parameter in constructorParameters)
                    {
                        parameters.Add(Create(parameter.ParameterType));
                    }
                }
                return constructor.Invoke(parameters.ToArray());
            }
            catch
            {
                return Activator.CreateInstance(type);
            }
        }

        private ConstructorInfo? Constructor(ConstructorInfo[] constructors)
        {
            if (constructors.Length > 1)
            {
                var AllConstructors =
                constructors.OrderByDescending(ob => ob.GetParameters().Length).ToList();
                return AllConstructors[0];
            }
            else return constructors.First();
        }
        private void FillFieldsAndProperties(object resultT)
        {
            var type = resultT.GetType();
            var publicFields = type.GetFields(BindingFlags.Public | BindingFlags.Static |
               BindingFlags.Instance).Where(f => !f.IsLiteral); ;

            foreach (var field in publicFields)
            {
                try
                {
                    field.SetValue(resultT, Create(field.FieldType));
                }
                catch
                {
                    field.SetValue(resultT, null);
                }
            }

            var properties = type.GetProperties();

            foreach (var property in properties)
            {
                if (property.SetMethod != null)
                {
                    try
                    {
                        property.SetValue(resultT, Create(property.PropertyType));
                    }
                    catch
                    {
                        property.SetValue(resultT, null);
                    }
                }
            }
        }
    }
}
