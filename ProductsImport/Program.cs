using Microsoft.Extensions.Configuration;
using ProductsImport.Infrastructure.Services;
using ProductsImport.Models.Configurations;
using System;

namespace ProductsImport
{
    class Program
    {
        static void Main(string[] args)
        {
            var settings = GetAppSettings();

            /** Engine does all the work **/
            var engine = Ioc.Container.Resolve<IEngine>();
            engine.Process(settings);
            
            Console.ReadLine();

        }

        // This method is setting the application configuration, returning the container
        private static AppSettings GetAppSettings()
        {
            var configurationBuilder = new ConfigurationBuilder()
                            .SetBasePath(Settings.ConfigPath)
                            .AddJsonFile("Autofac.json")
                            .AddJsonFile("appSettings.json", optional: false, reloadOnChange: true);

            IConfigurationRoot configuration = configurationBuilder.Build();

            Ioc.BuildContainer(configuration);
            var settings = new AppSettings();
            configuration.Bind(settings);
            return settings;
        }       
    }
}
