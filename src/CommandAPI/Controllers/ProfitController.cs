using CommandAPI.Models;
using CommandAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CommandAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProfitController : ControllerBase
    {
        private readonly IProfitService _profitService;

        public ProfitController(IProfitService profitService)
        {
            _profitService = profitService;
        }

        [HttpGet("calculate-margin")]
        // [HttpGet("calculate-margin", Name= "Calculate Net Margin")]
        // [SwaggerOperation("API to calculate the margin and profit of a trade / deal", Description = "This operation calculates the margin of a transaction / deal based on the number of products to sell and a selling price of each product.")]
        // [Produces("application/json")]
        // [ProducesResponseType(typeof(Profit), StatusCodes.Status200OK)]
        // [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Profit> CalculateNetMargin([FromQuery] int numberOfProducts,
                                                      [FromQuery] double sellingPrice)
        {
            var profit = _profitService.CalculateNetMargin(numberOfProducts, sellingPrice);
            if (profit == null)
                return NotFound();

            return Ok(profit);
        }


        
    }
}