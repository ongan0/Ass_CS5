using _1_AppData._1_DataProcessing.Models;
using _2_AppApi.ViewModels.OrderDetail;
using _2_AppApi.ViewModels.Reviews;

namespace _2_AppApi._1_Treatment.IServices
{
    public interface IReviewsServices
    {
        public Task<int> AddAsync(CreateReviews Obj);
        public Task<int> UpdateAsync(Guid ID, CreateReviews Obj);
        public Task<int> RemoveAsync(Guid ID);
        public Task<Reviews> GetByIdAsync(Guid ID);
        public Task<List<Reviews>> GetReviewsAsync();
    }
}
