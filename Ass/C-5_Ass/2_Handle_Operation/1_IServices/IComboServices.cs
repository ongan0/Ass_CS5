using Assignment_CS5_Share._1_Models;

namespace Assignment_Chsarp5_datntph19899._2_Handle_Operation._1_IServices
{
    public interface IComboServices
    {
        Task<List<Combo>> GetCombosAsync();
        Task<Combo> GetComboByIdAsync(Guid id);
        Task<Guid> AddComboAsync(Combo combo);
        Task<bool> UpdateComboAsync(Combo combo);
        Task<bool> DeleteComboAsync(Guid id);
    }
}
