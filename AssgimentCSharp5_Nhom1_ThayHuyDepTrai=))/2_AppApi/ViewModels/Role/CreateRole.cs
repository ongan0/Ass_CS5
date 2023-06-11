using System.ComponentModel.DataAnnotations;

namespace _2_AppApi.ViewModels.Role
{
    public class CreateRole
    {
        [Required(ErrorMessage = "Không được bỏ trống tên")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Không được bỏ trống mô tả")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Không được bỏ trống trạng thái")]
        public int Status { get; set; }
    }
}
