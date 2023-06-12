using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_AppData._1_DataProcessing.Models
{
    public class Bill
    {
        public Guid ID { get; set; }
        public Guid UserID { get; set; }// ID của khách hàng ở bảng User
        public string Receiver_Name { get; set; }
        public string Receiver_Address { get; set; }
        public string PhoneNumber { get; set; }
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
        //public virtual Delivery_Address Delivery_Address { get; set; }
    }
}
