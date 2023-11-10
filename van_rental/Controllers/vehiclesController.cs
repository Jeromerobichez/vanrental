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
        private readonly vehiclesService _vehiclesService;

        public vehiclesController(van_rentalContext context, vanRentalService vanRentalService, vehiclesService vehiclesService)
        {
            _context = context;
            _vanRentalService = vanRentalService;
            _vehiclesService = vehiclesService;
        }
        [HttpGet("GetAllVehicles")]
        public async Task<IActionResult> GetAllVehicles()
        {
            var vehicles = await _vehiclesService.GetDataOfVehicles();
            return Ok(vehicles);
        }
        [HttpGet("GetOneVehicleById")]
        public async Task<IActionResult> GetOneVehicleById(int id)
        {
            var vehicle = await _vehiclesService.GetOneVehicleAllInfos(id);
            return Ok(vehicle);
        }
        [HttpGet("GetInfosForOneOrMoreVehicles")]
        public async Task<List<getInfosOneVehicleResult>> GetInfosForOneOrMoreVehicles([FromQuery] int[] idsOfAvaiblablesVehicles)
        {

            var availablesVehicules = new List<getInfosOneVehicleResult>();
            foreach (int id in idsOfAvaiblablesVehicles)
            {
                availablesVehicules.Add(await _vehiclesService.GetOneVehicleAllInfos(id));
            };

            return availablesVehicules;
        }
        [HttpGet("GetAvailableVehicles")]
        public async Task<IActionResult> GetAvailableVehicles(string departureDate, string returnDate)
        {
            var availableVehicleAndModels = await _vehiclesService.getAvailableVehiclesBetweenTwoDates(departureDate, returnDate);

            return Ok(availableVehicleAndModels);
        }
        [HttpPost("PostNewVehicle")]
        public async Task<IActionResult> PostNewVehicle( DateTime registrationDate, int km, bool automaticGear, string? comments, int modelId, int colorId, bool hasBeenSold)
        {

            var newClient = await _vehiclesService.CreateNewVehicle(registrationDate, km, automaticGear, comments, modelId, colorId, hasBeenSold);


            return Ok(newClient);
        }
        [HttpPatch("UpdateVehicle")]
        public async Task<IActionResult> PatchVehicle([FromBody] JsonElement updateVehicle)
        {
            var updateData = JsonSerializer.Deserialize<Vehicles>(updateVehicle.GetRawText());
            if (updateData != null)
            {
                var modifiedVehicle = await _vehiclesService.ModifyAVehicle(updateData.Id, updateData.RegistrationDate, updateData.Km, updateData.AutomaticGear, updateData.Comments, updateData.ModelId, updateData.ColorId, updateData.HasBeenSold);
                return Ok(modifiedVehicle);
            }
            else { return BadRequest(); }
           
        }
        [HttpDelete("DeleteVehicle")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {

            var deletedVehicle = await _vehiclesService.DeleteVehicle(id);


            return Ok(deletedVehicle);
        }
    }

}
