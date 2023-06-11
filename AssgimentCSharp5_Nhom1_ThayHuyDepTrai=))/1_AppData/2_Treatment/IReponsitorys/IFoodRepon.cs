using _1_AppData._1_DataProcessing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_AppData._2_Treatment.IReponsitorys
{
    public interface IFoodRepon
    {
        public Task<bool> AddAsync(Food Obj);
        public Task<bool> UpdateAsync(Food Obj);
        public Task<bool> RemoveAsync(Food ID);
        public Task<Food> GetByIdAsync(Guid ID);
        public Task<List<Food>> GetFoodAsync();
    }
}
