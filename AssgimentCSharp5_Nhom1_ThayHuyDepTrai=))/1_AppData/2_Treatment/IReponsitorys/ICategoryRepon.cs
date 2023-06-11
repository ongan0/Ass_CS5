using _1_AppData._1_DataProcessing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_AppData._2_Treatment.IReponsitorys
{
    public interface ICategoryRepon
    {
        public Task<bool> AddAsync(Category Obj);
        public Task<bool> UpdateAsync(Category Obj);
        public Task<bool> RemoveAsync(Guid ID);
        public Task<Category> GetByIdAsync(Guid ID);
        public Task<List<Category>> GetCategoryAsync();
    }
}
