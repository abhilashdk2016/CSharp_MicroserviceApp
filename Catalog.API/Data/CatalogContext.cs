using System;
using Catalog.API.Data.Interfaces;
using Catalog.API.Entities;
using Catalog.API.Settings;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class CatalogContext : ICatalogContext
    {
        public CatalogContext(ICatalogDBSettings catalogDBSettings)
        {
            var client = new MongoClient(catalogDBSettings.ConnectionString);
            var database = client.GetDatabase(catalogDBSettings.DBName);
            Products = database.GetCollection<Product>(catalogDBSettings.CollectionName);
            CatalogContextSeed.Seed(Products);
        }

        public IMongoCollection<Product> Products { get; }
    }
}
