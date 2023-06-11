using _1_AppData._1_DataProcessing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_AppData._2_Treatment.IReponsitorys
{
    public interface IDelivery_AddressRepon
    {
        public Task<bool> AddAsync(Delivery_Address Obj);
        public Task<bool> UpdateAsync(Delivery_Address Obj);
        public Task<bool> RemoveAsync(Guid ID);
        public Task<Delivery_Address> GetByIdAsync(Guid ID);
        public Task<List<Delivery_Address>> GetDelivery_AddressAsync();
    }
}
