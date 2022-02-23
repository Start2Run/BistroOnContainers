using Microsoft.AspNetCore.Mvc;

namespace Bistro.WebApi.Controllers
{
    using Common.Models;
    using Persistence.Contracts;

    [ApiController]
    [Route("api/[Controller]")]
    public class FoodProductController : ControllerBase
    {
        private readonly ILogger<FoodProductController> _logger;

        private readonly IFoodProductContext m_foodProductContext;

        public FoodProductController(ILogger<FoodProductController> logger, IFoodProductContext foodProductContext)
        {
            _logger = logger;
            m_foodProductContext = foodProductContext;
        }

        // GET api/values
        [HttpGet("inventory")]
        public async Task<IEnumerable<FoodProduct>> Get()
        {
            var data = (await m_foodProductContext.GetProductsAsync()).AsQueryable();
            if (!data.Any())
            {
                await m_foodProductContext.AddProductsAsync(Enumerable.Range(1, 5).Select(index => new FoodProduct
                {
                    Name =$"Item {index}"
                }));
            }

            return data;
        }
    }
}