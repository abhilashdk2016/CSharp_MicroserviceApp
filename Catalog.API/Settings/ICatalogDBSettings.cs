using System;
namespace Catalog.API.Settings
{
    public interface ICatalogDBSettings
    {
        string CollectionName { get; set; }
        string ConnectionString { get; set; }
        string DBName { get; set; }
    }
}
