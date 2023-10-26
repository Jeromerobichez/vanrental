using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using vanRental.Models;
using vanRental.Controllers;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

namespace vanRental.Services
{
    public class vanRentalService
    {
        private readonly vanRentalContext _context;
        public vanRentalService(vanRentalContext context)
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
    }

    

}
