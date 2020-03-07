using Autofac;
using Microsoft.Extensions.Configuration;
using ProductsImport.Infrastructure.Services;
using System;

namespace ProductsImport
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = SetApplicationConfiguration();

            /** Engine does all the work **/
            var engine = container.Resolve<IEngine>();
            engine.Process();
            
            Console.ReadLine();

        }

        // This method is setting the application configuration, returning the container
        private static IContainer SetApplicationConfiguration()
        {
            var configurationBuilder = new ConfigurationBuilder()
                            .SetBasePath(Settings.ConfigPath)
                            .AddJsonFile("Autofac.json")
                            .AddJsonFile("appSettings.json", optional: false, reloadOnChange: true);

            IConfigurationRoot configuration = configurationBuilder.Build();

            Ioc.BuildContainer(configuration);

            return Ioc.Container;
        }       
    }
}
