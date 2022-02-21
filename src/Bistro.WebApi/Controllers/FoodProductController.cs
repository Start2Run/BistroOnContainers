using Microsoft.AspNetCore.Mvc;

namespace Bistro.WebApi.Controllers
{
    using Common.Models;

    [ApiController]
    [Route("api/[Controller]")]
    public class FoodProductController : ControllerBase
    {
        private readonly ILogger<FoodProductController> _logger;

        public FoodProductController(ILogger<FoodProductController> logger)
        {
            _logger = logger;
        }

        // GET api/values
        [HttpGet("inventory")]
        public IEnumerable<FoodProduct> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new FoodProduct
            {
               MiId = Guid.NewGuid()
            })
            .ToArray();
        }
    }
}