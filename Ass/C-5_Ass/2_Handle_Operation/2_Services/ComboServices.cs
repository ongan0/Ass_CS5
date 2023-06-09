using Assignment_CS5_Share._1_Models;
using Assignment_Chsarp5_datntph19899._1_DataProcessing._3_Context;
using Assignment_Chsarp5_datntph19899._2_Handle_Operation._1_IServices;
using Microsoft.EntityFrameworkCore;
using Assignment_Chsarp5_datntph19899._2_Handle_Operation._3_ViewModels;

namespace Assignment_Chsarp5_datntph19899._2_Handle_Operation._2_Services
{
    public class ComboServices : IComboServices
    {
        private readonly Assignment_Context _dbContext;

        public ComboServices(Assignment_Context dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ComboViewModels>> GetCombosAsync()
        {
            var lstCB = await _dbContext.Combos.ToListAsync();
            var lst = from a in lstCB
                      select new ComboViewModels
                      {
                          ID = a.ID,
                          FoodID = a.FoodID,
                          //thieu category o model
                          ComboName = a.ComboName,
                          Price = a.Price,
                          Description = a.Description,
                          Status = a.Status
                      };
            return lst.ToList();
        }

        public async Task<Combo> GetComboByIdAsync(Guid id)
        {
            return await _dbContext.Combos.FindAsync(id);
        }

        public async Task<bool> AddComboAsync(ComboViewModels combo)
        {
            try
            {
                var fo = await _dbContext.Combos.FindAsync(combo.FoodID);
                var ct = await _dbContext.Categorys.FindAsync(combo.CategoryID);
                var cb = new Combo()
                {
                    FoodID = fo.FoodID,
                    //thieu id category o model
                    ComboName = combo.ComboName,
                    Price = combo.Price,
                    Description = combo.Description,
                    Status = combo.Status
                };
                await _dbContext.Combos.AddAsync(cb);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public async Task<bool> UpdateComboAsync(ComboViewModels combo)
        {
            try
            {
                var cb = await _dbContext.Combos.FirstOrDefaultAsync(c => c.ID == combo.ID);
                cb.FoodID = combo.FoodID;
                cb.ComboName = combo.ComboName;
                cb.Price = combo.Price;
                cb.Description = combo.Description;
                cb.Status = combo.Status;
                _dbContext.Update(cb);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public async Task<bool> DeleteComboAsync(Guid id)
        {
            try
            {
                var combo = await _dbContext.Combos.FindAsync(id);
                if (combo == null)
                    return false;

                _dbContext.Combos.Remove(combo);
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
