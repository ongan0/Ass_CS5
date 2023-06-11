using _1_AppData._1_DataProcessing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_AppData._2_Treatment.IReponsitorys
{
    public interface IReviewsRepon
    {
        public Task<bool> AddAsync(Reviews Obj);
        public Task<bool> UpdateAsync(Reviews Obj);
        public Task<bool> RemoveAsync(Guid ID);
        public Task<Reviews> GetByIdAsync(Guid ID);
        public Task<List<Reviews>> GetReviewsAsync();
    }
}
