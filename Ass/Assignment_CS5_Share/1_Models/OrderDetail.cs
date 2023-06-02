namespace Assignment_CS5_Share._1_Models
{
    public class OrderDetail
    {
        public Guid ID { get; set; }
        public Guid OrderID { get; set; }
        public Guid FoodID { get; set; }
        public int Quantity { get; set; }

        public ICollection<Food> Food { get; set; }
        public virtual Order Order { get; set; }
    }
}
