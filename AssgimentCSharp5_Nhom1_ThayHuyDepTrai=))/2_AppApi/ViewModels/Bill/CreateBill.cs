using System.ComponentModel.DataAnnotations;

namespace _2_AppApi.ViewModels.Bill
{
    public class CreateBill
    {
        [Required(ErrorMessage = "Không được bỏ trống ....")]
        public Guid Delivery_AddressID { get; set; } // địa chỉ
        [Required(ErrorMessage = "Không được bỏ trống địa chỉ")]
        public string Shipping_Address { get; set; } // địa chỉ gửi hàng
        [Required(ErrorMessage = "Không được bỏ trống ID của khách hàng")]
        public Guid UserID { get; set; }// ID của khách hàng ở bảng User
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime Delivery_Date { get; set; }//thời gian giao hàng
        [Required(ErrorMessage = "Không được bỏ trống thời gian giao hàng")]
        public DateTime Actual_Delivery_Date { get; set; } // thời gian dự kiến giao hàng thành công
        public int Delivery_Status { get; set; }//trạng thái giao hàng
        public decimal Shipping_Cost { get; set; }//phí vận chuyển
        public int Payment_Status { get; set; }//trạng thái thanh toán
    }
}
