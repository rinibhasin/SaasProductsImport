using ProductsImport.Models.Configurations;

namespace ProductsImport
{
    public interface IEngine
    {
        void Process(AppSettings settings);
    }
}
