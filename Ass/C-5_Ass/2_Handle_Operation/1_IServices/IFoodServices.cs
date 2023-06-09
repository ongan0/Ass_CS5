using Assignment_Chsarp5_datntph19899._2_Handle_Operation._3_ViewModels;
using Assignment_CS5_Share._1_Models;

namespace Assignment_Chsarp5_datntph19899._2_Handle_Operation._1_IServices
{
    public interface IFoodServices
    {
        public Task<List<FoodViewModels>> GetFoodsAsync();
        public Task<Food> GetFoodByIdAsync(Guid id);
        public Task<bool> AddFoodAsync(FoodViewModels food);
        public Task<bool> UpdateFoodAsync(FoodViewModels food);
        public Task<bool> DeleteFoodAsync(Guid id);
    }
}
