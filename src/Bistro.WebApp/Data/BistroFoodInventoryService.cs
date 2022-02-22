namespace Bistro.WebApp.Data
{
    using Common.Models;
    using Newtonsoft.Json;

    public sealed class BistroFoodInventoryService
    {
        private readonly HttpClient m_httpClientFactory;

        public BistroFoodInventoryService(IHttpClientFactory httpClientFactory)
        {
            m_httpClientFactory = httpClientFactory.CreateClient("BistroWebApi");
        }

        internal async Task<IEnumerable<FoodProduct>> GetFoodProductsInventoryAsync()
        {
            try
            {
                var response = await m_httpClientFactory.GetAsync("api/FoodProduct/inventory");
                var content = await response.Content.ReadAsStringAsync();
                var items = JsonConvert.DeserializeObject<IEnumerable<FoodProduct>>(content);
                return items;
            }
            catch (Exception e)
            {
                return new List<FoodProduct>();
            }
        }
    }
}