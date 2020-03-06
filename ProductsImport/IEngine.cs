using Autofac;

namespace ProductsImport
{
    public interface IEngine
    {
        void Process(IContainer container);
    }
}
