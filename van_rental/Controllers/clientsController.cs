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
        [HttpPost("PostNewClient")]
        public async Task<IActionResult> PostNewClient([FromQuery] string lastName, string firstName, string tel, string mail)
        {

            var newClient = await _vanRentalService.CreateNewClient(lastName, firstName, tel, mail);


            return Ok(newClient);
        }
        [HttpPatch("UpdateAClient")]
        public async Task<IActionResult> PatchClient([FromQuery]
        int id,
       string? lastName,
       string? firstName,
       string? tel,
       string? mail
            )
        {

            var modifiedClient = await _vanRentalService.ModifyAClient(id, lastName, firstName, tel, mail);


            return Ok(modifiedClient);
        }
        [HttpDelete("DeleteAClient")]
        public async Task<IActionResult> DeleteAClient(int id)
        {

            var deletedClient = await _vanRentalService.DeleteAClient(id);


            return Ok(deletedClient);
        }
    }

}
