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
    }
}