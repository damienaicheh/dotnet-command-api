using CommandAPI.Models;
using CommandAPI.Services;
using Microsoft.AspNetCore.Mvc;

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