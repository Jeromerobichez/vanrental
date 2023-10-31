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
            var availableVehicle = await _vanRentalService.getAvailableVehiclesBetweenDate(departureDate, returnDate);
            return Ok(availableVehicle);
        }
        [HttpGet("GetInfosForOneOrMoreVehicles")]
        public async Task <List<getInfosOneVehicleResult>> GetInfosForOneOrMoreVehicles([FromQuery] int[] idsOfAvaiblablesVehicles)
        {


            var availablesVehicules = new List<getInfosOneVehicleResult>();
            foreach (int id in idsOfAvaiblablesVehicles){
                availablesVehicules.Add( await _vanRentalService.GetOneVehicleAllInfos(id));
            };

           
      
            var toto = 2;

            return availablesVehicules;
        }
    }
}