namespace ProductsImport.Infrastructure.Services
{
    public interface IIocContainer
    {
        TService Resolve<TService>();

        TService ResolveKeyed<TService>(string serviceKey);
    }
}
