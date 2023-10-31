using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using van_rental.Models;
using vanRental.Controllers;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Linq;

namespace vanRental.Services
{
    public class vanRentalService
    {
        private readonly van_rentalContext _context;
        private readonly van_rentalContext _contextProcedure;
        public vanRentalService(van_rentalContext context)
        {
            _context = context;
        
        }
        public List<Vehicles> GetDataOfVehicles()
        {
            try
            {
                var vehicles =  _context.Vehicles.ToList();
               
                return vehicles;
            }
            catch (Exception ex)
            {
               throw new Exception(ex.Message);
}
        }
        public Vehicles GetOneVehicle(int id)
        {
            try
            {
                var vehicle = _context.Vehicles.Where(x => x.Id == id).First();
                return vehicle;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public async Task <getInfosOneVehicleResult> GetOneVehicleAllInfos(int id)
        {
            try
            {
                var vehicleResult = await _context.Procedures.getInfosOneVehicleAsync(id);
                // On doit attendre que la tâche soit terminée pour pouvoir appeler .FirstOrDefault()
                var vehicle = vehicleResult.FirstOrDefault();

                return vehicle;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        public async Task<List<GetAvailablesVehiclesResult>> getAvailableVehiclesBetweenDate(DateTime departureDate, DateTime returnDate)

        }
    }

    

}
