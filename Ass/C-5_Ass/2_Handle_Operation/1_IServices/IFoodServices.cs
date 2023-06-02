using Assignment_CS5_Share._1_Models;

namespace Assignment_Chsarp5_datntph19899._2_Handle_Operation._1_IServices
{
    public interface IFoodServices
    {
        Task<List<Food>> GetFoodsAsync();
        Task<Food> GetFoodByIdAsync(Guid id);
        Task<Guid> AddFoodAsync(Food food);
        Task<bool> UpdateFoodAsync(Food food);
        Task<bool> DeleteFoodAsync(Guid id);
    }
}
