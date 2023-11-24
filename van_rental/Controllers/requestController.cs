using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using van_rental.Models;
using vanRental.Services;


namespace van_rental.requestControllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class requestController : ControllerBase
    {
        private readonly van_rentalContext _context;
        private readonly vanRentalService _vanRentalService;

        public requestController(van_rentalContext context, vanRentalService vanRentalService)
        {
            _context = context;
            _vanRentalService = vanRentalService;
        }
        [HttpPost("SendRentalRequest")]
        public IActionResult SendRentalRequest([FromBody] JsonElement theRequest)
        {
            var newRequest = JsonSerializer.Deserialize<Requests>(theRequest.GetRawText());
            newRequest.RequestDate = DateTime.UtcNow;
           
            _context.Requests.Add(newRequest);
            _context.SaveChanges(); // Enregistre les modifications dans la base de données

            return Ok("Réservation enregistrée avec succès.");
        }
    }

}
