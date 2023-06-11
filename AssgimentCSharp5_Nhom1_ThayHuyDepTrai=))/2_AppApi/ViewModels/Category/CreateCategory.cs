using System.ComponentModel.DataAnnotations;

namespace _2_AppApi.ViewModels.Category
{
    public class CreateCategory
    {
        [Required(ErrorMessage = "Không được bỏ trống food id")]
        public Guid FoodID { get; set; }
        [Required(ErrorMessage = "Không được bỏ trống tên")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Không được bỏ trống mô tả")]
        public string Description { get; set; }

    }
}
