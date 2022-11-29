using System.Text;

namespace Faker
{
    internal class UriGenerator : IGenerator
    {
        private static readonly Random _random = new();
        private static readonly StringGenerator _stringGenerator = new();
        public object Generate()
        {
            return RandomUri();
        }

        public Type GetGeneratorType()
        {
            return typeof(Uri);
        }

        private Uri RandomUri()
        {
            var uriBuilder = new UriBuilder();
            // fragment
            if (_random.NextDouble() < 0.4)
            {
                uriBuilder.Fragment = '#' + (string)_stringGenerator.Generate();
            }
            // host
            var host = new StringBuilder();
            var subdomainCount = _random.Next(1, 4);
            for (int i = 0; i < subdomainCount; i++)
            {
                host.Append(_stringGenerator.Generate());
                host.Append('.');
            }
            switch (_random.NextInt64(0, 4))
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
            uriBuilder.Host = host.ToString();

            // userName and password
            if (_random.NextDouble() < 0.4)
            {
                uriBuilder.Password = (string)_stringGenerator.Generate();
                uriBuilder.UserName = (string)_stringGenerator.Generate();
            }

            // scheme
            uriBuilder.Scheme = _random.NextDouble() < 0.5 ? "https:" : "http:";

            // path
            var path = new StringBuilder();
            var subdirCount = _random.Next(5);
            for (int i = 0; i < subdirCount; i++)
            {
                path.Append('/');
                path.Append(_stringGenerator.Generate());
            }
            uriBuilder.Path = path.ToString();

            // port    
            if (_random.NextDouble() < 0.2)
            {
                uriBuilder.Port = _random.Next(65536);
            }

            // query
            if (_random.NextDouble() < 0.6)
            {
                var queryCount = _random.Next(5);
                var query = new StringBuilder();
                for (int i = 0; i < queryCount; i++)
                {
                    _ = i > 0 ? query.Append('&') : query.Append('?');

                    query.Append(_stringGenerator.Generate());
                    query.Append('=');
                    query.Append(_stringGenerator.Generate());
                }
                uriBuilder.Query = query.ToString();
            }

            return uriBuilder.Uri;
        }
    }
}
