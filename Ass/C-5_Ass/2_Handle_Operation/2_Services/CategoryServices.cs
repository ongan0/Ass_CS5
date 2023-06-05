using Assignment_Chsarp5_datntph19899._1_DataProcessing._3_Context;
using Assignment_Chsarp5_datntph19899._2_Handle_Operation._1_IServices;
using Assignment_CS5_Share._1_Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment_Chsarp5_datntph19899._2_Handle_Operation._2_Services
{
    public class CategoryServices : ICategoryServices
    {
        private readonly Assignment_Context _dbContext;
        public CategoryServices(Assignment_Context assignment_Context)
        {
            _dbContext = assignment_Context;
        }
        public async Task<bool> AddAsync(Category Obj)
        {
            try
            {
                Obj.ID = Guid.NewGuid();
                await _dbContext.Categorys.AddAsync(Obj);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<Category> GetByIdAsync(Guid ID)
        {
            return await _dbContext.Categorys.FindAsync(ID);
        }

        public async Task<List<Category>> GetCategoryAsync()
        {
            return await _dbContext.Categorys.ToListAsync();
        }

        public async Task<bool> RemoveAsync(Guid ID)
        {
            try
            {
                var idCt = await _dbContext.Categorys.FirstOrDefaultAsync(c => c.ID == ID);
                if (idCt == null)
                {
                    return false;
                }
                _dbContext.Categorys.Remove(idCt);
                await _dbContext.SaveChangesAsync();
                return true;

            }
            catch (Exception)
            {
                return false;
            }



        }

        public async Task<bool> UpdateAsync(Category Obj)
        {
            try
            {
                var cate = await _dbContext.Categorys.FirstOrDefaultAsync(c => c.ID == Obj.ID);
                cate.FoodID = Obj.FoodID;
                cate.Name = Obj.Name;
                cate.Description = Obj.Description;
                _dbContext.Categorys.Attach(Obj);
                await Task.FromResult<Category>(_dbContext.Categorys.Update(Obj).Entity);

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
