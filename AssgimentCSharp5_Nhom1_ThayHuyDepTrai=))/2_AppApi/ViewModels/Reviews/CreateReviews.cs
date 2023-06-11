using System.ComponentModel.DataAnnotations;

namespace _2_AppApi.ViewModels.Reviews
{
    public class CreateReviews
    {
        [Required(ErrorMessage = "Không được bỏ trống FoodID")]
        public Guid FoodID { get; set; }
        [Required(ErrorMessage = "Không được bỏ trống UserID")]
        public Guid UserID { get; set; }
        [Required(ErrorMessage = "Không được bỏ trống Content")]
        public string Content { get; set; }
        [Required(ErrorMessage = "Không được bỏ trống Rating")]
        public string Rating { get; set; }
        [Required(ErrorMessage = "Không được bỏ trống Created_At")]
        public DateTime Created_At { get; set; }
        [Required(ErrorMessage = "Không được bỏ trống Updated_At")]
        public DateTime Updated_At { get; set; }
    }
}
