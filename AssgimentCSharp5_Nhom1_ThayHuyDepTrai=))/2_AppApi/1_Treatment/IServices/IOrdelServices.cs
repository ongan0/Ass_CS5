using _1_AppData._1_DataProcessing.Models;
using _2_AppApi.ViewModels.Ordel;
using _2_AppApi.ViewModels.Role;

namespace _2_AppApi._1_Treatment.IServices
{
    public interface IOrdelServices
    {
        public Task<int> AddAsync(CreateOrdel Obj);
        public Task<int> UpdateAsync(Guid ID, CreateOrdel Obj);
        public Task<int> RemoveAsync(Guid ID);
        public Task<Ordel> GetByIdAsync(Guid ID);
        public Task<List<Ordel>> GetOrdelAsync();
    }
}
