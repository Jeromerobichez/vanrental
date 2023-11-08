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
    }
}
    


