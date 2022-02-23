namespace Persistence
{
    using Bistro.Common.Models;
    using Contracts;
    using Microsoft.Extensions.Configuration;
    using Models;
    using MongoDB.Driver;

    public sealed class FoodProductContext : IFoodProductContext
    {
        private readonly IConfiguration m_configuration;

        private IMongoCollection<FoodProductPersistence> _products;

        public FoodProductContext(IConfiguration configuration)
        {
            m_configuration = configuration;
            Init();
        }

        public async Task AddProductsAsync(IEnumerable<FoodProduct> products)
        {
            await _products.InsertManyAsync(products.Select(x=>
                new FoodProductPersistence
                {
                    Name = x.Name,
                    Category = x.Category,
                    Price = x.Price,
                    Image = x.Image
                }));
        }

        public async Task<IEnumerable<FoodProduct>> GetProductsAsync()
        {
            var response = await _products.FindAsync(p => true);
            while (await response.MoveNextAsync())
            {
                return response?.Current?.Select(x =>
                new FoodProduct
                {
                    Id = x.Id,
                    Name = x.Name,
                    Category = x.Category,
                    Price = x.Price,
                    Image = x.Image
                }) ?? new List<FoodProduct>();
            }

            return new List<FoodProduct>();
        }

        private void Init()
        {
            try
            {
                var client = new MongoClient(m_configuration["DatabaseSettings:ConnectionString"]);
                var database = client.GetDatabase(m_configuration["DatabaseSettings:DatabaseName"]);
                var collectionName = m_configuration["DatabaseSettings:CollectionName"];
                //database.DropCollection(collectionName);
                _products = database.GetCollection<FoodProductPersistence>(collectionName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}