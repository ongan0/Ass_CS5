using _1_AppData._1_DataProcessing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_AppData._2_Treatment.IReponsitorys
{
    public interface IBillRepon
    {
        public Task<bool> AddAsync(Bill Obj);
        public Task<bool> UpdateAsync(Bill Obj);
        public Task<bool> RemoveAsync(Bill Obj);
        public Task<Bill> GetByIdAsync(Guid ID);
        public Task<List<Bill>> GetBillAsync();
    }
}
