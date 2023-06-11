using System.ComponentModel.DataAnnotations;

namespace _2_AppApi.ViewModels.Coupons
{
    public class CreateCoupons
    {
        [Required(ErrorMessage = "Không được bỏ trống food id")]
        public Guid FoodID { get; set; }
        [Required(ErrorMessage = "Không được bỏ trống combo id")]
        public Guid ComboID { get; set; }
        [Required(ErrorMessage = "Không được bỏ trống Coupon_Code")]
        public string Coupon_Code { get; set; } //mã giảm giá                                        
        [Required(ErrorMessage = "Không được bỏ trống Discount_Type")]
        public string Discount_Type { get; set; } //loại giảm giá
        [Required(ErrorMessage = "Không được bỏ trống Discount_Amount")]
        public string Discount_Amount { get; set; }//số tiền hoặc phần trăm
        [Required(ErrorMessage = "Không được bỏ trống Minimum_Spend")]
        public decimal Minimum_Spend { get; set; }//giá trị tối thiêu để sử dụng
        [Required(ErrorMessage = "Không được bỏ trống Maximum_Discount_Amount")]
        public decimal Maximum_Discount_Amount { get; set; }//Giới hạn giá trị giảm giá tối đa mà mã giảm giá có thể cung cấp.
        [Required(ErrorMessage = "Không được bỏ trống Expiration_Date")]
        public DateTime Expiration_Date { get; set; }//ngày hết hạn
        [Required(ErrorMessage = "Không được bỏ trống Create_At")]
        public DateTime Create_At { get; set; }
        [Required(ErrorMessage = "Không được bỏ trống Update_At")]
        public DateTime Update_At { get; set; }
    }
}
