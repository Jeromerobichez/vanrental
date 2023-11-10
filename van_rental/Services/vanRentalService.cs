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
    public class vanRentalService
    {
        private readonly van_rentalContext _context;
        private readonly van_rentalContext _contextProcedure;
        private readonly vehiclesService _vehiclesService;
        public vanRentalService(van_rentalContext context, vehiclesService vehiclesService)
        {
            _context = context;
            _vehiclesService = vehiclesService;

        }
        
        public List<VehicleModels> GetModelsInfos()
        {
            try
            {
                var models = _context.VehicleModels.ToList();

                return models;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
       
        
        
        public async Task<getInfosOneModelResult> GetInfosOneModel(int id)
        {
            try
            {
              
                var modelResult = await _context.Procedures.getInfosOneModelAsync(id);
                // On doit attendre que la tâche soit terminée pour pouvoir appeler .FirstOrDefault()
               
                var model = modelResult.FirstOrDefault();

                return model;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        
        public async Task <List<getInfosOneModelResult>> GetInfosModelsById(List<int> ids)
        {
            try
            {
               var selectedModels = new List<getInfosOneModelResult>();
                foreach (int id in ids)
                {
                    var modelResult = await _context.Procedures.getInfosOneModelAsync(id);
                    // On doit attendre que la tâche soit terminée pour pouvoir appeler .FirstOrDefault()
                    var model = modelResult.FirstOrDefault();
                    selectedModels.Add(model);
                }
              
              
             

                return selectedModels;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


       

        public Task<IEnumerable<getInfosOneVehicleResult>> GetInfosForOneOrMoreVehicles(int[] idsOfAvaiblablesVehicles)
        {


           var availablesVehicules =  idsOfAvaiblablesVehicles.Select(id => _vehiclesService.GetOneVehicleAllInfos(id));


            return (Task<IEnumerable<getInfosOneVehicleResult>>)availablesVehicules;
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

            var clientToDelete = await _context.Procedures.deleteClientAsync(id);
            return clientToDelete;
        }
        
        
         
        
    }
 


    }
    


