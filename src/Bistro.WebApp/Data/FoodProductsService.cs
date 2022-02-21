namespace Bistro.WebApp.Data
{
    using Common.Models;
    using Newtonsoft.Json;

    public class FoodProductsService
    {
        private readonly HttpClient m_httpClientFactory;

        public FoodProductsService(IHttpClientFactory httpClientFactory)
        {
            m_httpClientFactory = httpClientFactory.CreateClient("BistroWebApi");
        }

        public async Task<IEnumerable<FoodProduct>> GetFoodProductsInventoryAsync()
        {
           var response= await m_httpClientFactory.GetAsync("api/FoodProduct/inventory");
           var content = await response.Content.ReadAsStringAsync();
           var items = JsonConvert.DeserializeObject<IEnumerable<FoodProduct>>(content);
           return items;
        }
    }
}