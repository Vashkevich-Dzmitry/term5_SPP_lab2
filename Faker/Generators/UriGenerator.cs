using System.Text;
using Faker.Interfaces;

namespace Faker.Generators
{
    internal class UriGenerator : IGenerator
    {
        private const int maxStringLength = 16;
        private const int minStringLength = 4;
        private const double fragmentGenerateProbability = 0.4;
        private const double passwordAndUserNameGenerateProbability = 0.3;
        private const double portGenerateProbability = 0.2;
        private const double queryGenerateProbability = 0.6;

        public object Generate(Type type, IGeneratorContext context)
        {
            return GenerateRandomUri(context);
        }

        public bool CanGenerate(Type type)
        {
            return type == typeof(Uri);
        }

        private Uri GenerateRandomUri(IGeneratorContext context)
        {
            var uriBuilder = new UriBuilder();

            // fragment
            if (context.Random.NextDouble() < fragmentGenerateProbability)
            {
                uriBuilder.Fragment = GenerateRandomFragment(context);
            }

            // host
            uriBuilder.Host = GenerateRandomHost(context);

            // userName and password
            if (context.Random.NextDouble() < passwordAndUserNameGenerateProbability)
            {
                uriBuilder.Password = GenerateRandomPassword(context);
                uriBuilder.UserName = GenerateRandomUserName(context);

            }

            // scheme
            uriBuilder.Scheme = GenerateRandomScheme(context);

            // path
            uriBuilder.Path = GenerateRandomPath(context);

            // port    
            if (context.Random.NextDouble() < portGenerateProbability)
            {
                uriBuilder.Port = GenerateRandomPort(context);
            }

            // query
            if (context.Random.NextDouble() < queryGenerateProbability)
            {
                uriBuilder.Query = GenerateRandomQuery(context);
            }

            return uriBuilder.Uri;
        }

        private string GenerateRandomFragment(IGeneratorContext context)
        {
            return new string('#' + GenerateRandomString(context));

        }
        private string GenerateRandomHost(IGeneratorContext context)
        {
            var host = new StringBuilder();
            var subdomainCount = context.Random.Next(1, 4);
            for (int i = 0; i < subdomainCount; i++)
            {
                host.Append(GenerateRandomString(context));
                host.Append('.');
            }
            switch (context.Random.NextInt64(0, 4))
            {
                case 0:
                    host.Append("by");
                    break;
                case 1:
                    host.Append("ru");
                    break;
                case 2:
                    host.Append("com");
                    break;
                case 3:
                    host.Append("net");
                    break;
                case 4:
                    host.Append("org");
                    break;
            }
            return host.ToString();
        }
        private string GenerateRandomPassword(IGeneratorContext context)
        {
            return GenerateRandomString(context);
        }

        private string GenerateRandomUserName(IGeneratorContext context)
        {
            return GenerateRandomString(context);
        }

        private string GenerateRandomScheme(IGeneratorContext context)
        {
            return context.Random.NextDouble() < 0.5 ? "https:" : "http:";
        }
        private string GenerateRandomPath(IGeneratorContext context)
        {
            var path = new StringBuilder();
            var subdirCount = context.Random.Next(5);
            for (int i = 0; i < subdirCount; i++)
            {
                path.Append('/');
                path.Append(GenerateRandomString(context));
            }
            return path.ToString();
        }
        private int GenerateRandomPort(IGeneratorContext context)
        {

            return context.Random.Next(65536);

        }
        private string GenerateRandomQuery(IGeneratorContext context)
        {

            var queryCount = context.Random.Next(5);
            var query = new StringBuilder();
            for (int i = 0; i < queryCount; i++)
            {
                _ = i > 0 ? query.Append('&') : query.Append('?');

                query.Append(GenerateRandomString(context));
                query.Append('=');
                query.Append(GenerateRandomString(context));
            }
            return query.ToString();

        }

        private string GenerateRandomString(IGeneratorContext context)
        {
            int stringLength = (int)new Random().NextInt64(minStringLength, maxStringLength);
            char[] str = new char[stringLength];

            for (int i = 0; i < stringLength; i++)
            {
                str[i] = context.ValidCharacters[new Random().Next(context.ValidCharacters.Length)];
            }
            return new string(str);
        }
    }
}
