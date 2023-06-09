using Assignment_CS5_Share._1_Models;
using Assignment_Chsarp5_datntph19899._1_DataProcessing._3_Context;
using Assignment_Chsarp5_datntph19899._2_Handle_Operation._1_IServices;
using Microsoft.EntityFrameworkCore;
using Assignment_Chsarp5_datntph19899._2_Handle_Operation._3_ViewModels;

namespace Assignment_Chsarp5_datntph19899._2_Handle_Operation._2_Services
{
    public class FoodServices : IFoodServices
    {
        private readonly Assignment_Context _dbContext;

        public FoodServices(Assignment_Context dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<FoodViewModels>> GetFoodsAsync()
        {
            var lstdb = await _dbContext.Foods.ToListAsync();

            var lstF = from a in lstdb
                       select new FoodViewModels
                       {
                           ID = a.ID,
                           FoodName = a.FoodName,
                           Price = a.Price,
                           Description = a.Description
                       };
            return lstF.ToList();
        }

        public async Task<Food> GetFoodByIdAsync(Guid id)
        {
            return await _dbContext.Foods.FindAsync(id);
        }

        public async Task<bool> AddFoodAsync(FoodViewModels foods)
        {
            try
            {
                var fo = new Food()
                {

                    FoodName = foods.FoodName,
                    Price = foods.Price,
                    Description = foods.Description,
                };

                await _dbContext.Foods.AddAsync(fo);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public async Task<bool> UpdateFoodAsync(FoodViewModels food)
        {
            try
            {
                var fo = await _dbContext.Foods.ToListAsync();
                var idf = fo.FirstOrDefault(c => c.ID == food.ID);
                idf.FoodName = food.FoodName;
                idf.Price = food.Price;
                idf.Description = food.Description;
                //_dbContext.Foods.Attach(idf);
                //await Task.FromResult<Food>(_dbContext.Foods.Update(idf).Entity);
                _dbContext.Update(idf);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public async Task<bool> DeleteFoodAsync(Guid id)
        {
            try
            {
                var food = await _dbContext.Foods.FindAsync(id);
                if (food == null)
                    return false;

                _dbContext.Foods.Remove(food);
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
