using Assignment_CS5_Share._1_Models;
using Assignment_Chsarp5_datntph19899._1_DataProcessing._3_Context;
using Assignment_Chsarp5_datntph19899._2_Handle_Operation._1_IServices;
using Microsoft.EntityFrameworkCore;

namespace Assignment_Chsarp5_datntph19899._2_Handle_Operation._2_Services
{
    public class ComboServices : IComboServices
    {
        private readonly Assignment_Context _dbContext;

        public ComboServices(Assignment_Context dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Combo>> GetCombosAsync()
        {
            return await _dbContext.Combos.ToListAsync();
        }

        public async Task<Combo> GetComboByIdAsync(Guid id)
        {
            return await _dbContext.Combos.FindAsync(id);
        }

        public async Task<Guid> AddComboAsync(Combo combo)
        {
            combo.ID = Guid.NewGuid();
            await _dbContext.Combos.AddAsync(combo);
            await _dbContext.SaveChangesAsync();
            return combo.ID;
        }

        public async Task<bool> UpdateComboAsync(Combo combo)
        {
            _dbContext.Entry(combo).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteComboAsync(Guid id)
        {
            var combo = await _dbContext.Combos.FindAsync(id);
            if (combo == null)
                return false;

            _dbContext.Combos.Remove(combo);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
