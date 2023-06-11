using _1_AppData._1_DataProcessing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_AppData._2_Treatment.IReponsitorys
{
    public interface IOrderDetailRepon
    {
        public Task<bool> AddAsync(OrderDetail Obj);
        public Task<bool> UpdateAsync(OrderDetail Obj);
        public Task<bool> RemoveAsync(Guid ID);
        public Task<OrderDetail> GetByIdAsync(Guid ID);
        public Task<List<OrderDetail>> GetOrderDetailAsync();
    }
}
