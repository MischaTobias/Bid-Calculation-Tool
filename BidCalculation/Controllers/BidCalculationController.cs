using BidCalculation.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BidCalculation.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BidCalculationController(IBidCalculationService BidCalculationService) : ControllerBase
    {
        private readonly IBidCalculationService _BidCalculationService = BidCalculationService;

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] double vehiclePrice, [FromQuery] int vehicleTypeId)
        {
            try
            {
                if(vehiclePrice == 0 || vehicleTypeId == 0) throw new Exception("Vehicle price or vehicle type not received.");
                
                var bidCalculation = await _BidCalculationService.GetTotalBasedOnVehicleType(vehiclePrice, vehicleTypeId);
                return Ok(bidCalculation);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"A problem occured while trying to calculate the bid. \n {ex.Message}" );
            }
        }
    }
}
