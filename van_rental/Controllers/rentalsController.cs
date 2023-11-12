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
        private readonly rentalsService _rentalsService;

        public rentalsController(van_rentalContext context,
            vanRentalService vanRentalService,
            rentalsService rentalsService
            )
        {
            _context = context;
            _vanRentalService = vanRentalService;
            _rentalsService = rentalsService;
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

            var newRental = await _rentalsService.CreateNewRental(startDate, endDate, clientId, vehicleId);


            return Ok(newRental);
        }
        [HttpPatch("UpdateARental")]
        public async Task<IActionResult> PatchRental([FromBody] JsonElement modifiedRental)
        //int id,
        //DateTime? startDate,
        //DateTime? endDate,
        //int? clientId,
        //int? vehicleId)
        {
            var deserializeRental = JsonSerializer.Deserialize<Rentals>(modifiedRental);
            var modifiedRentalReadyToSend = await _rentalsService.ModifyARental(
                deserializeRental.Id,
                deserializeRental.DepartureDate,
                deserializeRental.ReturnDate,
                deserializeRental.ClientId,
                deserializeRental.VehicleId);


            return Ok(modifiedRentalReadyToSend);
        }
        [HttpDelete("DeleteARental")]
        public async Task<IActionResult> DeleteARental(int id)
        {

            var deletedRental = await _rentalsService.DeleteARental(id);


            return Ok(deletedRental);
        }
    }

}
