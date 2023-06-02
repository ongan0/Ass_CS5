namespace Assignment_CS5_Share._1_Models
{
    public class Order
    {
        public Guid OrderID { get; set; }
        public Guid UserID { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public int Status { get; set; }

        public ICollection<OrderDetail> OrderDetail { get; set; }

        public virtual User Users { get; set; }
    }
}
