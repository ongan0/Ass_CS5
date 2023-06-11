using _1_AppData._1_DataProcessing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_AppData._2_Treatment.IReponsitorys
{
    public interface IOrdelRepon
    {
        public Task<bool> AddAsync(Ordel Obj);
        public Task<bool> UpdateAsync(Ordel Obj);
        public Task<bool> RemoveAsync(Guid ID);
        public Task<Ordel> GetByIdAsync(Guid ID);
        public Task<List<Ordel>> GetOrdelAsync();
    }
}
