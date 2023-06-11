using System.ComponentModel.DataAnnotations;

namespace _2_AppApi.ViewModels.Combo
{
    public class CreateCombo
    {
        [Required(ErrorMessage = "Không được bỏ trống food id")]
        public Guid FoodID { get; set; }
        [Required(ErrorMessage = "Không được bỏ trống tên combo")]
        public string ComboName { get; set; }
        [Required(ErrorMessage = "Không được bỏ trống giá")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Không được bỏ trống mô tả")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Không được bỏ trống trạng thái")]
        public int Status { get; set; }
    }
}
