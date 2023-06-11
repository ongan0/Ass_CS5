using System.ComponentModel.DataAnnotations;

namespace _2_AppApi.ViewModels.Delivery_Address
{
    public class CreateDelivery_Address
    {
        [Required(ErrorMessage = "Không được bỏ trống user id")]
        public Guid UserID { get; set; }
        [Required(ErrorMessage = "Không được bỏ trống Receiver_Name")]
        public string Receiver_Name { get; set; }
        [Required(ErrorMessage = "Không được bỏ trống Receiver_Address")]
        public string Receiver_Address { get; set; }
        [Required(ErrorMessage = "Không được bỏ trống PhoneNumber")]
        public string PhoneNumber { get; set; }
    }
}
