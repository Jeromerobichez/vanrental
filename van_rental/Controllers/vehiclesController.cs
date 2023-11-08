using Microsoft.AspNetCore.Mvc;
using van_rental.Models;
using vanRental.Services;
using System.Text.Json;

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
        [HttpGet("GetAllVehicles")]
        public async Task<IActionResult> GetAllVehicles()
        {
            var vehicles = await _vanRentalService.GetDataOfVehicles();
            return Ok(vehicles);
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
        public async Task<IActionResult> PatchVehicle([FromBody] JsonElement updateVehicle)
        {
            var updateData = JsonSerializer.Deserialize<Vehicles>(updateVehicle);
            
            if (updateData != null)
            {
                var modifiedVehicle = await _vanRentalService.ModifyAVehicle(updateData.Id, updateData.RegistrationDate, updateData.Km, updateData.AutomaticGear, updateData.Comments, updateData.ModelId, updateData.ColorId, updateData.HasBeenSold);
                return Ok(modifiedVehicle);
            }
            else { return BadRequest(); }
           
        }
        [HttpDelete("DeleteVehicle")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {

            var deletedVehicle = await _vanRentalService.DeleteVehicle(id);


            return Ok(deletedVehicle);
        }
    }

}
