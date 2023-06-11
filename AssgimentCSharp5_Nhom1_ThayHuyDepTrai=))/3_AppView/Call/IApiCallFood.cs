using _1_AppData._1_DataProcessing.Models;
using _2_AppApi.ViewModels.Food;
using Refit;

namespace _3_AppView.Call
{
    public interface IApiCallFood
    {
        [Get("/Food")]
        Task<List<Food>> GetByFood();
        [Post("/Food")]
        Task<int> Create(CreateFood createCustomer);
    }
}
