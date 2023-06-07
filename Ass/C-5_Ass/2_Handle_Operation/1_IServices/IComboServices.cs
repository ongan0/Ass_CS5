using Assignment_Chsarp5_datntph19899._2_Handle_Operation._3_ViewModels;
using Assignment_CS5_Share._1_Models;

namespace Assignment_Chsarp5_datntph19899._2_Handle_Operation._1_IServices
{
    public interface IComboServices
    {
        public Task<List<ComboViewModels>> GetCombosAsync();
        public Task<Combo> GetComboByIdAsync(Guid id);
        public Task<bool> AddComboAsync(ComboViewModels combo);
        public Task<bool> UpdateComboAsync(ComboViewModels combo);
        public Task<bool> DeleteComboAsync(Guid id);
    }
}
