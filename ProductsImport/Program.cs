namespace ProductsImport
{
    using Autofac;
    using Autofac.Configuration;
    using Microsoft.Extensions.Configuration;
    using ProductsImport.Infrastructure.DataProviders;

    class Program
    {
        static void Main(string[] args)
        {
            var container = SetApplicationConfiguration();
            var inputString = "import capterra feed-products/capterra.yaml";
            var name = "capterra";

            var provider = container.ResolveKeyed<IDataProvider>(name);
            provider.ParseInput();

        }

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
            return builder.Build();
        }
    }
}
