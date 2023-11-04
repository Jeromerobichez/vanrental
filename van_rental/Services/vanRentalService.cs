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
                var vehicles = _context.Vehicles.ToList();

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


        public async Task<List<GetAvailablesVehiclesResult>> getAvailableVehiclesBetweenTwoDates(DateTime departureDate, DateTime returnDate)
        {
           
                if (returnDate > departureDate)
                {
                    var vehicleResult = await _context.Procedures.GetAvailablesVehiclesAsync(departureDate, returnDate);
              

                return vehicleResult;
            }
            else throw new Exception("la date de retour est antérieure à la date de départ");


        }

        public Task<IEnumerable<getInfosOneVehicleResult>> GetInfosForOneOrMoreVehicles(int[] idsOfAvaiblablesVehicles)
        {


           var availablesVehicules =  idsOfAvaiblablesVehicles.Select(id => GetOneVehicleAllInfos(id));


            return (Task<IEnumerable<getInfosOneVehicleResult>>)availablesVehicules;
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
        public async Task<int> CreateNewClient(string lastName, string firstName, string tel, string mail)
        {

            var newClientToCreate = await _context.Procedures.createNewClientAsync(lastName, firstName, tel, mail);
            return newClientToCreate;
        }
        public async Task<int> ModifyAClient(int id, string? lastName, string?firstName, string? tel, string? mail)
        {

            var rentalToCreate = await _context.Procedures.UpdateAClientAsync(id, lastName, firstName, tel, mail);
            return rentalToCreate;
        }
        public async Task<int> DeleteAClient(int id)
        {

            var rentalToCreate = await _context.Procedures.deleteClientAsync(id);
            return rentalToCreate;
        }
    }
 


    }
    


