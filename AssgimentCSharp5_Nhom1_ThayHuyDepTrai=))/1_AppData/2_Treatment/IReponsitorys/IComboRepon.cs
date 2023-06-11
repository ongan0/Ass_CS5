using _1_AppData._1_DataProcessing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_AppData._2_Treatment.IReponsitorys
{
    public interface IComboRepon
    {
        public Task<bool> AddAsync(Combo Obj);
        public Task<bool> UpdateAsync(Combo Obj);
        public Task<bool> RemoveAsync(Guid ID);
        public Task<Combo> GetByIdAsync(Guid ID);
        public Task<List<Combo>> GetComboAsync();
    }
}
