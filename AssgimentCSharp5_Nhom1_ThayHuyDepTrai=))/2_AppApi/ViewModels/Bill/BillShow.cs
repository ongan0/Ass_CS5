namespace _2_AppApi.ViewModels.Bill
{
    public class BillShow
    {
        public Guid ID { get; set; }
        public string Account { get; set; }
        public string UserName { get; set; }
        public Guid UserID { get; set; }// khách hàng ở bảng User
        public Guid Delivery_AddressID { get; set; } // địa chỉ quán
        public string Shipping_Address { get; set; } // địa chỉ gửi hàng
        public string PhoneNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime Delivery_Date { get; set; }//thời gian giao hàng
        public DateTime Actual_Delivery_Date { get; set; } // thời gian giao hàng thành công
        public int Delivery_Status { get; set; }//trạng thái giao hàng
        public decimal Shipping_Cost { get; set; }//phí vận chuyển
        public int Payment_Status { get; set; }//trạng thái thanh toán
    }
}
