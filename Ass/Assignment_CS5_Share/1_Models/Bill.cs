using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment_CS5_Share._1_Models
{
    public class Bill
    {
        public Guid ID { get; set; }
        public Guid UserID { get; set; }// ID của khách hàng ở bảng User
        public Guid Delivery_AddressID { get; set; } // địa chỉ
        public string Shipping_Address { get; set; } // địa chỉ gửi hàng
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime Delivery_Date { get; set; }//thời gian giao hàng
        public DateTime Actual_Delivery_Date { get; set; } // thời gian giao hàng thành công
        public int Delivery_Status { get; set; }//trạng thái giao hàng
        public decimal Shipping_Cost { get; set; }//phí vận chuyển
        public int Payment_Status { get; set; }//trạng thái thanh toán

        public virtual User User { get; set; }
        public ICollection<BillDetail> BillDetails { get; set; }
        public virtual Delivery_Address Delivery_Address { get; set; }
    }
}
