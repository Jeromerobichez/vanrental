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
    }

}
