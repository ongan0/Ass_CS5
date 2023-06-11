using _1_AppData._1_DataProcessing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_AppData._2_Treatment.IReponsitorys
{
    public interface IBillDetailRepon
    {
        public Task<bool> AddAsync(BillDetail Obj);
        public Task<bool> UpdateAsync(BillDetail Obj);
        public Task<bool> RemoveAsync(Guid ID);
        public Task<BillDetail> GetByIdAsync(Guid ID);
        public Task<List<BillDetail>> GetBillDetailAsync();
    }
}
