using System.ComponentModel.DataAnnotations;

namespace _2_AppApi.ViewModels.OrderDetail
{
    public class CreateOrderDetail
    {
        [Required(ErrorMessage = "Không được bỏ trống orderid")]
        public Guid OrderID { get; set; }
        [Required(ErrorMessage = "Không được bỏ trống foodid")]
        public Guid FoodID { get; set; }
        [Required(ErrorMessage = "Không được bỏ trống số lượng")]
        public int Quantity { get; set; }
    }
}
