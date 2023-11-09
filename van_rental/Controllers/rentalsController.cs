using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using van_rental.Models;
using vanRental.Services;


namespace van_rental.rentalsControllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class rentalsController : ControllerBase
    {
        private readonly van_rentalContext _context;
        private readonly vanRentalService _vanRentalService;

        public rentalsController(van_rentalContext context, vanRentalService vanRentalService)
        {
            _context = context;
            _vanRentalService = vanRentalService;
        }
        [HttpGet("GetAllRentals")]
        public async Task<IActionResult> GetAllRentals()
        {
          var allRentals = await _context.Procedures.GetRentalsInfosAsync();

            return Ok(allRentals);
        }
        [HttpPost("PostNewRental")]
        public async Task<IActionResult> PostNewRental([FromQuery] DateTime startDate, DateTime endDate, int clientId, int vehicleId)
        {

            var newRental = await _vanRentalService.CreateNewRental(startDate, endDate, clientId, vehicleId);


            return Ok(newRental);
        }
        [HttpPatch("UpdateARental")]
        public async Task<IActionResult> PatchRental([FromQuery]
        int id,
        DateTime? startDate,
        DateTime? endDate,
        int? clientId,
        int? vehicleId)
        {

            var modifiedRental = await _vanRentalService.ModifyARental(id, startDate, endDate, clientId, vehicleId);


            return Ok(modifiedRental);
        }
        [HttpDelete("DeleteARental")]
        public async Task<IActionResult> DeleteARental(int id)
        {

            var deletedRental = await _vanRentalService.DeleteARental(id);


            return Ok(deletedRental);
        }
    }

}
