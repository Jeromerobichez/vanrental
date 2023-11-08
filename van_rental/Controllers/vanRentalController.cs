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
        
        [HttpGet("GetAllModels")]
        public IActionResult GetAllModels()
        {
            var models = _vanRentalService.GetModelsInfos();
            return Ok(models);
        }
        [HttpGet("GetOneModelById")]
        public async Task<IActionResult> GetModelById(int id)
        {
            var oneModel = await _vanRentalService.GetInfosOneModel(id);
            return Ok(oneModel);
        }
        //[HttpGet("GetOneVehicleById")]
        //public async Task<IActionResult> GetOneVehicleById(int id)
        //{
        //    var vehicle = await _vanRentalService.GetOneVehicleAllInfos(id);
        //    return Ok(vehicle);
        //}
        [HttpGet("GetAvailableVehicles")]
        public async Task<IActionResult> GetAvailableVehicles(string departureDate, string returnDate)
        {
            var availableVehicleAndModels = await _vanRentalService.getAvailableVehiclesBetweenTwoDates(departureDate, returnDate);
            
            return Ok(availableVehicleAndModels);
        }
        [HttpGet("GetModelsById")]
        public async Task<IActionResult> GetModelsById([FromHeader] List<int> ids)
        {
            var availableModels = await _vanRentalService.GetInfosModelsById(ids);
            return Ok(availableModels);
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
        public async Task<IActionResult> PostNewRental([FromQuery] DateTime startDate ,DateTime endDate, int clientId, int vehicleId )
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

        [HttpDelete("DeleteARental")]
        public async Task<IActionResult> DeleteARental(int id)
        {

            var deletedRental = await _vanRentalService.DeleteARental(id);


            return Ok(deletedRental);
        }
    }
}