namespace Assignment_CS5_Share._1_Models
{
    public class Coupons
    {
        public Guid ID { get; set; }
        public Guid FoodID { get; set; }
        public Guid ComboID { get; set; }
        public string Coupon_Code { get; set; } //mã giảm giá
        public string Discount_Type { get; set; } //loại giảm giá
        public string Discount_Amount { get; set; }//số tiền hoặc phần trăm
        public decimal Minimum_Spend { get; set; }//giá trị tối thiêu để sử dụng
        public decimal Maximum_Discount_Amount { get; set; }//Giới hạn giá trị giảm giá tối đa mà mã giảm giá có thể cung cấp.
        public DateTime Expiration_Date { get; set; }//ngày hết hạn
        public DateTime Create_At { get; set; }
        public DateTime Update_At { get; set; }

        public ICollection<Combo> Combo { get; set; }
        public ICollection<Food> Food { get; set; }
    }
}
