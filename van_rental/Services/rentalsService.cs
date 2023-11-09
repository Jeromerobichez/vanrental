using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using van_rental.Models;
using vanRental.Controllers;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Linq;
using Microsoft.AspNetCore.Identity;

namespace vanRental.Services
{
    public class rentalsService
    {
        private readonly van_rentalContext _context;
        private readonly van_rentalContext _contextProcedure;
        public rentalsService(van_rentalContext context)
        {
            _context = context;

        }
        public async Task<List<GetRentalsInfosResult>> GetDatasOfRentals()
        {
            try
            {
                var rentalsResults = await _context.Procedures.GetRentalsInfosAsync();
                return rentalsResults;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<int> CreateNewRental(DateTime startDate, DateTime endDate, int clientId, int vehicleId)
        {

            var rentalToCreate = await _context.Procedures.createNewRentalAsync(startDate, endDate, clientId, vehicleId);
            return rentalToCreate;
        }
        public async Task<int> ModifyARental(int id, DateTime? startDate, DateTime? endDate, int? clientId, int? vehicleId)
        {

            var rentalToCreate = await _context.Procedures.updateARentalAsync(id, startDate, endDate, clientId, vehicleId);
            return rentalToCreate;
        }
        public async Task<int> DeleteARental(int id)
        {

            var rentalToDelete = await _context.Procedures.deleteRentalAsync(id);
            return rentalToDelete;
        }
    }
}
    


