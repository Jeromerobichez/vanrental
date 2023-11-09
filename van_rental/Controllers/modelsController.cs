using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using van_rental.Models;
using vanRental.Services;


namespace van_rental.modelsControllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class modelsController : ControllerBase
    {
        private readonly van_rentalContext _context;
        private readonly vanRentalService _vanRentalService;

        public modelsController(van_rentalContext context, vanRentalService vanRentalService)
        {
            _context = context;
            _vanRentalService = vanRentalService;
        }
        [HttpGet("GetAllModels")]
        public IActionResult GetAllModels()
        {
            var models = _vanRentalService.GetModelsInfos();
            return Ok(models);
        }
        [HttpGet("GetModelsById")]
        public async Task<IActionResult> GetModelsById([FromHeader] List<int> ids)
        {
            var availableModels = await _vanRentalService.GetInfosModelsById(ids);
            return Ok(availableModels);
        }
    }

}
