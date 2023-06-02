using Assignment_CS5_Share._1_Models;
using Assignment_Chsarp5_datntph19899._1_DataProcessing._3_Context;
using Assignment_Chsarp5_datntph19899._2_Handle_Operation._1_IServices;
using Microsoft.EntityFrameworkCore;

namespace Assignment_Chsarp5_datntph19899._2_Handle_Operation._2_Services
{
    public class FoodServices : IFoodServices
    {
        private readonly Assignment_Context _dbContext;

        public FoodServices(Assignment_Context dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Food>> GetFoodsAsync()
        {
            return await _dbContext.Foods.ToListAsync();
        }

        public async Task<Food> GetFoodByIdAsync(Guid id)
        {
            return await _dbContext.Foods.FindAsync(id);
        }

        public async Task<Guid> AddFoodAsync(Food food)
        {
            food.ID = Guid.NewGuid();
            await _dbContext.Foods.AddAsync(food);
            await _dbContext.SaveChangesAsync();
            return food.ID;
        }

        public async Task<bool> UpdateFoodAsync(Food food)
        {
            _dbContext.Entry(food).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteFoodAsync(Guid id)
        {
            var food = await _dbContext.Foods.FindAsync(id);
            if (food == null)
                return false;

            _dbContext.Foods.Remove(food);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
