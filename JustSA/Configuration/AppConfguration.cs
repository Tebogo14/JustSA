using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JustSA.Configuration
{
    public static class AppConfguration
    {
        private static readonly ConcurrentDictionary<string, IConfigurationRoot> _configurationCache; 

        static AppConfguration()
        {
            _configurationCache = new ConcurrentDictionary<string, IConfigurationRoot>();
        }

        public static IConfiguration Get(string path, string environmentName = null, bool addUserSecrets = false)
        {
            var cache = path + "#" + environmentName + "#" + addUserSecrets;
            return _configurationCache.GetOrAdd(
                cache, _ => BuildConfiguration(path));
        }

        private static IConfigurationRoot BuildConfiguration(string path)
        {
            var builder = new ConfigurationBuilder()
                           .SetBasePath(path)
                           .AddJsonFile("appsetting.json", optional: true, reloadOnChange: true);

            builder = builder.AddEnvironmentVariables();

            return builder.Build();
        }
    }
}
