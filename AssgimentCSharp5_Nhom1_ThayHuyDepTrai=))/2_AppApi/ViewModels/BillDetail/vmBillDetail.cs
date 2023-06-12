using System.ComponentModel.DataAnnotations;

namespace _2_AppApi.ViewModels.BillDetail
{
    public class vmBillDetail
    {
        public string FoodName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
    }
}
