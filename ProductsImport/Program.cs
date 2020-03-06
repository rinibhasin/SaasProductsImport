namespace ProductsImport
{
    using Autofac;
    using Autofac.Configuration;
    using Microsoft.Extensions.Configuration;
    using ProductsImport.Models.Configurations;
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            var container = SetApplicationConfiguration();

            /** Engine does all the work **/
            var engine = container.Resolve<IEngine>();
            engine.Process(container);
            
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
            var module = new ConfigurationModule(configuration);
            var builder = new ContainerBuilder();
            builder.RegisterModule(module);
            AppSettings settings = new AppSettings();
            return builder.Build();
        }
    }
}
