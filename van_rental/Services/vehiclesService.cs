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
    public class vehiclesService
    {
        private readonly van_rentalContext _context;
        private readonly van_rentalContext _contextProcedure;
        public vehiclesService(van_rentalContext context)
        {
            _context = context;

        }
        public async Task<List<getInfosOneVehicleResult>> GetDataOfVehicles()
        {
            try
            {
                var vehiclesData = new List<getInfosOneVehicleResult>();
                var vehiclesIds = _context.Vehicles.Select(x => x.Id).ToList();
                foreach (var vehicleId in vehiclesIds)
                {
                    var vehicle = await GetOneVehicleAllInfos(vehicleId);
                    vehiclesData.Add(vehicle);
                }

                return vehiclesData;
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
        public async Task<getInfosOneVehicleResult> GetOneVehicleAllInfos(int id)
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

        }
        public async Task<getInfosOneModelAndPriceResult> GetInfosOneModelAndPrice(
            int id,
            DateTime departureDate,
            DateTime returnDate)
        {
            try
            {

                var modelAndPriceResult = await _context.Procedures.getInfosOneModelAndPriceAsync(id, departureDate, returnDate);

                var modelAndPrice = modelAndPriceResult.FirstOrDefault();

                return modelAndPrice;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public async Task<availableVehiclesAndModels> getAvailableVehiclesBetweenTwoDates(string departureDate, string returnDate)
        {
            var vehiclesAndModels = new availableVehiclesAndModels();
            var parsedDepartureDate = DateTime.Parse(departureDate);
            var parsedReturnDate = DateTime.Parse(returnDate);
            if (parsedReturnDate > parsedDepartureDate)
            {
                var vehicleResult = await _context.Procedures.GetAvailablesVehiclesAsync(parsedDepartureDate, parsedReturnDate);
                var modelsAvailable = new List<getInfosOneModelAndPriceResult>();
                vehiclesAndModels.VehiclesAvailable = vehicleResult;
                HashSet<int> uniqueModelIds = new HashSet<int>();
                foreach (var vehicle in vehicleResult)
                {
                    uniqueModelIds.Add(vehicle.model_id);
                }
                foreach (int item in uniqueModelIds)
                {
                    var model = await GetInfosOneModelAndPrice(item, parsedDepartureDate, parsedReturnDate);
                    modelsAvailable.Add(model);
                }
                vehiclesAndModels.ModelsAvailable = modelsAvailable;

                return vehiclesAndModels;
            }
            else throw new Exception("la date de retour est antérieure à la date de départ");


        }
        public async Task<int> CreateNewVehicle(DateTime? registrationDate, int? km, bool? automaticGear, string? comments, int modelId, int colorId, bool hasBeenSold)
        {

            var newVehicleToCreate = await _context.Procedures.createNewVehicleAsync(registrationDate, km, automaticGear, comments, modelId, colorId, hasBeenSold);

            return newVehicleToCreate;
        }
        public async Task<int> ModifyAVehicle(int id, DateTime? registrationDate, int? km, bool? automaticGear, string? comments, int? modelId, int? colorId, bool? hasBeenSold)
        {

            var vehicleToModdify = await _context.Procedures.updateVehicleAsync(id, registrationDate, km, automaticGear, comments, modelId, colorId, hasBeenSold);


            var toto = 12; 
            return vehicleToModdify;
        }
        public async Task<int> DeleteVehicle(int id)
        {

            var vehicleToDelete = await _context.Procedures.deleteVehicleAsync(id);
            return vehicleToDelete;
        }
    }
}
    


