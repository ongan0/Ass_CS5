using _1_AppData._1_DataProcessing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_AppData._2_Treatment.IReponsitorys
{
    public interface ICouponsRepon
    {
        public Task<bool> AddAsync(Coupons Obj);
        public Task<bool> UpdateAsync(Coupons Obj);
        public Task<bool> RemoveAsync(Guid ID);
        public Task<Coupons> GetByIdAsync(Guid ID);
        public Task<List<Coupons>> GetCouponsAsync();
    }
}
