using Assignment_CS5_Share._1_Models;

namespace Assignment_Chsarp5_datntph19899._2_Handle_Operation._1_IServices
{
    public interface IBillServices
    {
        Task<List<Bill>> GetBills();
        Task<Bill> GetBillById(Guid id);
        Task<Bill> CreateBill(Bill bill);
        Task<Bill> UpdateBill(Guid id, Bill bill);
        Task<bool> DeleteBill(Guid id);
    }
}
