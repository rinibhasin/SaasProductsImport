using Autofac;
using Microsoft.Extensions.Configuration;

namespace ProductsImport.Infrastructure.Services
{
    // Wrapper class for autofac so that we can chose other containers easily in future without changing much code.
    public static class Ioc
    {
        private static ContainerBuilder builder = new ContainerBuilder();

        public static IIocContainer Container { get; set; }

        public static void BuildContainer(IConfiguration configuration)
        {
            Container = new IocContainerProxy(builder, configuration);
        }
    }
}
