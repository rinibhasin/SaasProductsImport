using Autofac;
using Autofac.Configuration;
using Microsoft.Extensions.Configuration;

namespace ProductsImport.Infrastructure.Services
{
    public class IocContainerProxy : IIocContainer
    {
        private IContainer autofacContainer;

        public IocContainerProxy(ContainerBuilder builder, IConfiguration configuration)
        {
            builder.RegisterInstance(configuration).As<IConfiguration>();
            builder.RegisterModule(new ConfigurationModule(configuration));
            autofacContainer = builder.Build();
        }

        public TService Resolve<TService>()
        {
            return autofacContainer.Resolve<TService>();
        }

        public TService ResolveKeyed<TService>(string serviceKey)
        {
            return autofacContainer.ResolveKeyed<TService>(serviceKey);
        }
    }
}
