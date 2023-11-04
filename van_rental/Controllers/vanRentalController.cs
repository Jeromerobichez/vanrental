using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using van_rental.Models;
using vanRental.Services;

namespace vanRental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class vanRentalController : ControllerBase
    {

        private readonly van_rentalContext _context;
        private readonly vanRentalService _vanRentalService;

        public vanRentalController(van_rentalContext context, vanRentalService vanRentalService)
        {
            _context = context;
            _vanRentalService = vanRentalService;
        }

        [HttpGet("test", Name = "test")]
        public IActionResult Get()
        {
           
            return Ok("Ceci est une réponse de l'API.");
        }
        [HttpGet("GetKm", Name = "GetKm")]
        public async Task<IActionResult> GetKm()
        {
            var vehicles = await _context.Vehicles.Select(x => x.Km).ToListAsync();
           
            return Ok(vehicles);
        }
        [HttpGet("GetAllVehicles")]
        public IActionResult GetAllVehicles()
        {
            var vehicles = _vanRentalService.GetDataOfVehicles();
            return Ok(vehicles);
        }
        [HttpGet("GetOneVehicleById")]
        public async Task<IActionResult> GetOneVehicleById(int id)
        {
            var vehicle = await _vanRentalService.GetOneVehicleAllInfos(id);
            return Ok(vehicle);
        }
        [HttpGet("GetAvailableVehicles")]
        public async Task<IActionResult> GetAvailableVehicles(DateTime departureDate, DateTime returnDate)
        {
            var availableVehicle = await _vanRentalService.getAvailableVehiclesBetweenTwoDates(departureDate, returnDate);
            return Ok(availableVehicle);
        }
        [HttpGet("GetInfosForOneOrMoreVehicles")]
        public async Task <List<getInfosOneVehicleResult>> GetInfosForOneOrMoreVehicles([FromQuery] int[] idsOfAvaiblablesVehicles)
        {

            var availablesVehicules = new List<getInfosOneVehicleResult>();
            foreach (int id in idsOfAvaiblablesVehicles){
                availablesVehicules.Add( await _vanRentalService.GetOneVehicleAllInfos(id));
            };

            return availablesVehicules;
        }
        [HttpPost("PostNewRental")]
        public async Task<IActionResult> Post([FromQuery] DateTime startDate ,DateTime endDate, int clientId, int vehicleId )
        {

            var newRental = await _vanRentalService.CreateNewRental(startDate, endDate, clientId, vehicleId);
            

            return Ok(newRental);
        }
        [HttpPatch("UpdateARental")]
        public async Task<IActionResult> Patch([FromQuery] int id, DateTime? startDate, Nullable<DateTime> endDate, Nullable<int> clientId, Nullable<int> vehicleId)
        {

            var newRental = await _vanRentalService.ModifyARental(id, startDate, endDate, clientId, vehicleId);


            return Ok(newRental);
        }
    }
}