using Assignment_Chsarp5_datntph19899._1_DataProcessing._3_Context;
using Assignment_Chsarp5_datntph19899._2_Handle_Operation._1_IServices;
using Assignment_CS5_Share._1_Models;

namespace Assignment_Chsarp5_datntph19899._2_Handle_Operation._2_Services
{
    public class OrderDetailService : IOrderDetailService
    {
        Assignment_Context _dbcontext;
        public OrderDetailService(Assignment_Context assignment_Context)
        {
            _dbcontext = assignment_Context;
        }
        public Task<bool> CreateNewOrderDetails(OrderDetail orderDetail)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteOrderDetails(Guid id)
        {
            try
            {
                var Od = await _dbcontext.OrdelDetail.FindAsync(id);
                _dbcontext.Remove(Od);
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Task<List<OrderDetail>> GetAllOrderDetails()
        {
            throw new NotImplementedException();
        }

        public Task<OrderDetail> GetOrderDetailsByUserId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateOrderDetails(OrderDetail orderDetail)
        {
            throw new NotImplementedException();
        }
    }
}
