using System;
namespace Pik.Models
{
    public class PikDatabaseSetting : IPikDatabaseSetting
    {
        public string UserCollectionName { get; set; }
        public string PostCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IPikDatabaseSetting
    {
        string UserCollectionName { get; set; }
        string PostCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
