using System.ComponentModel.DataAnnotations;

namespace _2_AppApi.ViewModels.User
{
    public class CreateUser
    {
        [Required(ErrorMessage = "Không được bỏ trống chức vụ")]
        public Guid IDRole { get; set; }
        [Required(ErrorMessage = "Không được bỏ trống tài khoản")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Không được bỏ trống mật khẩu")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Không được bỏ trống tên")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Không được bỏ trống mô tả")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Không được bỏ trống email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Không được bỏ trống số điện thoại")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Không được bỏ trống trạng thái")]
        public int Status { get; set; }
    }
}
