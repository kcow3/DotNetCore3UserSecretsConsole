using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace UserSecrets
{
    class Program
    {
        public static IConfigurationRoot Configuration { get; set; }

        static void Main(string[] args)
        {
            #region SecretSetup

            var devEnvironmentVariable = Environment.GetEnvironmentVariable("NETCORE_ENVIRONMENT");

            var isDevelopment = string.IsNullOrEmpty(devEnvironmentVariable) ||
                                devEnvironmentVariable.ToLower() == "development";

            var builder = new ConfigurationBuilder();

            builder
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            if (isDevelopment)
            {
                builder.AddUserSecrets<Program>();
            }

            Configuration = builder.Build();

            IServiceCollection services = new ServiceCollection();

            services
                .Configure<Secrets>(Configuration.GetSection("SecretStuff"))
                .AddOptions()
                .AddSingleton<ISecretService, SecretService>()
                .BuildServiceProvider();

            var serviceProvider = services.BuildServiceProvider();
            var secretService = serviceProvider.GetService<ISecretService>();
            #endregion

            Console.WriteLine("App to demonstrate using user secrets in .net Core 3.x console application");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");

            Console.WriteLine("printing the secret here: " + secretService.GetASecret());

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
        }
    }
}

//Manage user secrets looks like this:
//{
//  "SecretStuff:ApiKey": "RandomKeyHere"
//}
