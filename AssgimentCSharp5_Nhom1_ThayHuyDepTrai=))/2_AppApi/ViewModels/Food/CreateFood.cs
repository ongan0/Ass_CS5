using System.ComponentModel.DataAnnotations;

namespace _2_AppApi.ViewModels.Food
{
    public class CreateFood
    {
        [Required(ErrorMessage = "Không được bỏ trống tên món")]
        public string FoodName { get; set; }
        [Required(ErrorMessage = "Không được bỏ trống giá")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Không được bỏ trống ảnh")]
        public string Images { get; set; }
        [Required(ErrorMessage = "Không được bỏ trống mô tả")]
        public string Description { get; set; }
    }
}
