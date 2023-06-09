using Assignment_CS5_Share._1_Models;

namespace Assignment_Chsarp5_datntph19899._2_Handle_Operation._1_IServices
{
    public interface IBillDetailServices
    {
        Task<List<BillDetail>> GetBillDetails();
        Task<BillDetail> GetBillDetailById(Guid id);
        Task<BillDetail> CreateBillDetail(BillDetail billDetail);
        Task<BillDetail> UpdateBillDetail(Guid id, BillDetail billDetail);
        Task<bool> DeleteBillDetail(Guid id);
    }
}
