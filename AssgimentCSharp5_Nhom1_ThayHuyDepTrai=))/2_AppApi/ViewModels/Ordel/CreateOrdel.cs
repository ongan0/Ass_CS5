using System.ComponentModel.DataAnnotations;

namespace _2_AppApi.ViewModels.Ordel
{
    public class CreateOrdel
    {
        [Required(ErrorMessage = "Không được bỏ trống id user")]
        public Guid UserID { get; set; }
        [Required(ErrorMessage = "Không được bỏ trống ngày order")]
        public DateTime OrderDate { get; set; }
        [Required(ErrorMessage = "Không được bỏ trống tổng đơn giá")]
        public decimal TotalPrice { get; set; }
        [Required(ErrorMessage = "Không được bỏ trống tổng trang thai")]
        public int Status { get; set; }
    }
}
