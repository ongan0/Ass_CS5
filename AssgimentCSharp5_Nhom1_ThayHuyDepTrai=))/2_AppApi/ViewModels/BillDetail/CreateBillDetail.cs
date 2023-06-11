using System.ComponentModel.DataAnnotations;

namespace _2_AppApi.ViewModels.BillDetail
{
    public class CreateBillDetail
    {
        [Required(ErrorMessage = "Không được bỏ trống bill id")]
        public Guid BillID { get; set; }
        [Required(ErrorMessage = "Không được bỏ trống food id")]
        public Guid FoodID { get; set; }
        [Required(ErrorMessage = "Không được bỏ trống giá")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Không được bỏ trống số lượng")]
        public int Quantity { get; set; }
    }
}
