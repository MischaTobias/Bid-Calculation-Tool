using BidCalculation.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BidCalculation.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VehicleTypeController(IVehicleTypeService vehicleTypeService) : ControllerBase
    {
        private readonly IVehicleTypeService _vehicleTypeService = vehicleTypeService;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var vehicleType = await _vehicleTypeService.GetAllVehicleTypesAsync();
                return Ok(vehicleType);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"A problem occured while trying to retrieve the vehicle types. \n {ex.Message}");
            }
        }
    }
}
