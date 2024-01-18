// Create a profits controller class

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CommandAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProfitsController : Controller
    {
        [HttpGet]
        [SwaggerOperation("API to calculate the margin and profit of a trade / deal", Description = "This operation calculates the margin of a transaction / deal based on the number of products to sell and a selling price of each product.")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Profit), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("calculate-margin")]
        public IActionResult CalculateNetMargin([SwaggerParameter(Description = "Number of products to sell", Required = true)] [FromQuery] int numberOfProducts, 
                                                [SwaggerParameter(Description = "Unit price per product", Required = true)] [FromQuery] double sellingPrice)
        {
            double productionCost = 1.0;
            double operationCostUnder50 = 15.0;
            double operationCostOver50 = 5.0;
            double taxUnder50 = 0.10;
            double taxOver50 = 0.02;

            double totalRevenue = numberOfProducts * sellingPrice;
            double totalProductionCost = numberOfProducts * productionCost;
            double tax = numberOfProducts < 50 ? totalRevenue * taxUnder50 : totalRevenue * taxOver50;
            double operationCost = numberOfProducts < 50 ? operationCostUnder50 : operationCostOver50;

            double netMargin = totalRevenue - totalProductionCost - tax - operationCost;

            return Ok(new Profit()
            {
                NumberOfProducts = numberOfProducts,
                SellingPrice = sellingPrice,
                NetMargin = netMargin
            });
        }
    }

    public class Profit
    {
        public int NumberOfProducts { get; set; }
        public double SellingPrice { get; set; }
        public double NetMargin { get; set; }
    }
}