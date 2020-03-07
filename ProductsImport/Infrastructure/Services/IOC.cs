using Autofac;
using Autofac.Configuration;
using Microsoft.Extensions.Configuration;

namespace ProductsImport.Infrastructure.Services
{
    // Wrapper class for autofac so that we can chose other containers easily in future without changing much code.
    public static class Ioc
    {
        private static ContainerBuilder builder = new ContainerBuilder();

        public static IContainer Container { get; set; }

        public static void BuildContainer(IConfiguration configuration)
        {
            builder.RegisterModule(new ConfigurationModule(configuration));
            Container = builder.Build();
        }

        public static TService Resolve<TService>()
        {
            return Container.Resolve<TService>();
        }

        public static TService ResolveKeyed<TService>(string serviceKey)
        {
            return Container.ResolveKeyed<TService>(serviceKey);
        }
    }
}
