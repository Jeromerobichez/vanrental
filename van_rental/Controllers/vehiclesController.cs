using Microsoft.AspNetCore.Mvc;
using van_rental.Models;
using vanRental.Services;

namespace van_rental.vehiclesControllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class vehiclesController : ControllerBase
    {
        private readonly van_rentalContext _context;
        private readonly vanRentalService _vanRentalService;

        public vehiclesController(van_rentalContext context, vanRentalService vanRentalService)
        {
            _context = context;
            _vanRentalService = vanRentalService;
        }
        [HttpGet("GetOneVehicleById")]
        public async Task<IActionResult> GetOneVehicleById(int id)
        {
            var vehicle = await _vanRentalService.GetOneVehicleAllInfos(id);
            return Ok(vehicle);
        }
        [HttpPost("PostNewVehicle")]
        public async Task<IActionResult> PostNewVehicle( DateTime registrationDate, int km, bool automaticGear, string? comments, int modelId, int colorId, bool hasBeenSold)
        {

            var newClient = await _vanRentalService.CreateNewVehicle(registrationDate, km, automaticGear, comments, modelId, colorId, hasBeenSold);


            return Ok(newClient);
        }
        [HttpPatch("UpdateVehicle")]
        public async Task<IActionResult> PatchVehicle(
            int id,
            DateTime? registrationDate,
            int? km,
            bool? automaticGear,
            string? comments, 
            int? modelId, 
            int? colorId,
            bool? hasBeenSold
            )
        {

            var modifiedVehicle = await _vanRentalService.ModifyAVehicle(id, registrationDate, km, automaticGear, comments, modelId, colorId, hasBeenSold);


            return Ok(modifiedVehicle);
        }
        [HttpDelete("DeleteVehicle")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {

            var deletedVehicle = await _vanRentalService.DeleteVehicle(id);


            return Ok(deletedVehicle);
        }
    }

}
