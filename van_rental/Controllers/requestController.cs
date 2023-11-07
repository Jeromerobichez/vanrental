using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public IActionResult SendRentalRequest(string dateDepart, string dateRetour, string modeleVehicule, string id, string message)
        {

        var reservation = new Requests
            {
            DepartureDateRequested = DateTime.Parse(dateDepart),
            ReturnDateRequested = DateTime.Parse(dateRetour),
            ModelVehicleRequested = modeleVehicule,
            ModelId = id,
            MessageRequest = message
            };

            _context.Requests.Add(reservation);
            _context.SaveChanges(); // Enregistre les modifications dans la base de données

            return Ok("Réservation enregistrée avec succès.");
        }
    }

}
