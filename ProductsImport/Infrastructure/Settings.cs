namespace ProductsImport
{
    using System.IO;

    public class Settings
    {
        public static string ConfigPath
        {
            get
            {
                return Path.Combine(Directory.GetCurrentDirectory(), "Configurations");
            }
        }
    }
}
