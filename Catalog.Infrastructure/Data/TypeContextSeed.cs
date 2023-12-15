using Catalog.Core.Entities;
using MongoDB.Driver;
using System.Text.Json;

namespace Catalog.Infrastructure.Data
{
    public class TypeContextSeed
    {
        public static void SeedData(IMongoCollection<ProductType> typeCollection)
        {
            bool CheckTypes = typeCollection.Find(b => true).Any();
            string path = Path.Combine("Data", "SeedData", "types.json"); //Docker
            //string path = "../Catalog.Infrastructure/Data/SeedData/types.json"; //IIS
            if (!CheckTypes)
            {
                var typesData = File.ReadAllText(path);
                var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);

                if (types != null)
                {
                    foreach (var type in types)
                    {
                        typeCollection.InsertOneAsync(type);
                    }
                }
            }
        }
    }
}
