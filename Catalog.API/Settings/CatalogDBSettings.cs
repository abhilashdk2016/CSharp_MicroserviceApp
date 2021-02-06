using System;
namespace Catalog.API.Settings
{
    public class CatalogDBSettings : ICatalogDBSettings
    {
        public CatalogDBSettings()
        {
        }

        public string CollectionName { get ; set ; }
        public string ConnectionString { get ; set ; }
        public string DBName { get ; set ; }
    }
}
