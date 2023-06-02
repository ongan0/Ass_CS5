namespace Assignment_CS5_Share._1_Models
{
    public class Express_Delivery
    {
        public Guid ID { get; set; }
        public string Sender_Name { get; set; }
        public string Sender_Address { get; set; }
        public string Receiver_Name { get; set; }
        public string Receiver_Address { get; set; }
        public DateTime Delivery_Date { get; set; }//ngày giao dự kiến
        public DateTime Actual_Delivery_Date { get; set; } // ngày giao thực tế nếu có
        public int Delivery_Status { get; set; }//trạng thái giao hàng
        public decimal Shipping_Cost { get; set; }//phí vận chuyển
        public int Payment_Status { get; set; }//trạng thái thanh toán
        public Guid IDBill { get; set; }
        //public virtual Users Users { get; set; }
        //public Guid IDUser { get; set; }
        //public virtual Bill Bill { get; set; }
    }
}
