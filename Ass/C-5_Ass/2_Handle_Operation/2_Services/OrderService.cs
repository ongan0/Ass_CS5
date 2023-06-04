using Assignment_Chsarp5_datntph19899._1_DataProcessing._3_Context;
using Assignment_Chsarp5_datntph19899._2_Handle_Operation._1_IServices;
using Assignment_CS5_Share._1_Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment_Chsarp5_datntph19899._2_Handle_Operation._2_Services
{
    public class OrderService : IOrderService
    {
        Assignment_Context _dbContext;
        public OrderService(Assignment_Context assignment_Context)
        {
            _dbContext = assignment_Context;
        }



        public async Task<bool> CreateNewOrder(Order order)
        {
            try
            {
                await _dbContext.AddAsync(order);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteOrder(Guid id)
        {
            try
            {
                var idO = await _dbContext.Orders.FindAsync(id);
                if (idO == null)
                {
                    return false;
                }
                _dbContext.Orders.Remove(idO);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<Order>> GetAllOrder()
        {
            return await _dbContext.Orders.ToListAsync();
        }

        public async Task<Order> GetOrderByUserId(Guid id)
        {
            return await _dbContext.Orders
                    .Include(c => c.OrderDetail)
                    .ThenInclude(b => b.Food)
                    .FirstOrDefaultAsync(c => c.User.ID == id);
        }

        public async Task<bool> UpdateOrder(Order order)
        {
            try
            {
                var idO = await _dbContext.Orders.FindAsync(order.OrderID);
                idO.OrderDate = order.OrderDate;
                idO.TotalPrice = order.TotalPrice;
                idO.Status = order.Status;
                _dbContext.Orders.Update(idO);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
