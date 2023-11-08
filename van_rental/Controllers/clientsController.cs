using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using van_rental.Models;
using vanRental.Services;


namespace van_rental.clientsControllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class clientsController : ControllerBase
    {
        private readonly van_rentalContext _context;
        private readonly vanRentalService _vanRentalService;

        public clientsController(van_rentalContext context, vanRentalService vanRentalService)
        {
            _context = context;
            _vanRentalService = vanRentalService;
        }
        [HttpGet("GetAllClients")]
        public IActionResult GetAllClients()
        {
          var allClients = _context.Clients.ToList();

            return Ok(allClients);
        }
    }

}
