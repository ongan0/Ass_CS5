using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Assignment_Chsarp5_datntph19899._1_DataProcessing._3_Context;
using Assignment_Chsarp5_datntph19899._2_Handle_Operation._1_IServices;
using Assignment_CS5_Share._1_Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment_Chsarp5_datntph19899._2_Handle_Operation._2_Services
{
    public class Express_DeliveryServices : IExpress_DeliveryServices
    {
        private readonly Assignment_Context _dbContext;

        public Express_DeliveryServices(Assignment_Context dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Express_Delivery>> GetExpressDeliveriesAsync()
        {
            return await _dbContext.Express_Deliveries.ToListAsync();
        }

        public async Task<Express_Delivery> GetExpressDeliveryByIdAsync(Guid id)
        {
            return await _dbContext.Express_Deliveries.FindAsync(id);
        }

        public async Task<Guid> AddExpressDeliveryAsync(Express_Delivery expressDelivery)
        {
            expressDelivery.ID = Guid.NewGuid();
            await _dbContext.Express_Deliveries.AddAsync(expressDelivery);
            await _dbContext.SaveChangesAsync();
            return expressDelivery.ID;
        }

        public async Task<bool> UpdateExpressDeliveryAsync(Express_Delivery expressDelivery)
        {
            _dbContext.Entry(expressDelivery).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteExpressDeliveryAsync(Guid id)
        {
            var expressDelivery = await _dbContext.Express_Deliveries.FindAsync(id);
            if (expressDelivery == null)
                return false;

            _dbContext.Express_Deliveries.Remove(expressDelivery);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
