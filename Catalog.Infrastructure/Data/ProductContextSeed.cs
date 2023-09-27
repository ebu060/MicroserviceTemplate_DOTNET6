using Catalog.Core.Entities;
using MongoDB.Driver;
using System.Text.Json;

namespace Catalog.Infrastructure.Data
{
    public class ProductContextSeed
    {
        public static void SeedData(IMongoCollection<Product> productCollection)
        {
            bool CheckProducts = productCollection.Find(b => true).Any();
            string path = Path.Combine("Data", "SeedData", "products.json");
            if (!CheckProducts)
            {
                var productsData = File.ReadAllText(path);
                var products = JsonSerializer.Deserialize<List<Product>>(productsData);

                if (products != null)
                {
                    foreach (var type in products)
                    {
                        productCollection.InsertOneAsync(type);
                    }
                }
            }
        }
    }
}
