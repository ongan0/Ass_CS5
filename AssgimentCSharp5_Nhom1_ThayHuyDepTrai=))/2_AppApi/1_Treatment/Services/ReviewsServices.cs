using _1_AppData._1_DataProcessing.Models;
using _1_AppData._2_Treatment.IReponsitorys;
using _1_AppData._2_Treatment.Reponsitorys;
using _2_AppApi._1_Treatment.IServices;
using _2_AppApi.ViewModels.Reviews;

namespace _2_AppApi._1_Treatment.Services
{
    public class ReviewsServices : IReviewsServices
    {
        IReviewsRepon _IReviewsRepon;
        IFoodRepon _IFoodRepon;
        IUserRepon _IUserRepon;
        public ReviewsServices()
        {
            _IFoodRepon = new FoodRepon();
            _IReviewsRepon = new ReviewsRepon();
            _IUserRepon = new UserRepon();
        }
        public async Task<int> AddAsync(CreateReviews Obj)
        {
            var food = await _IFoodRepon.GetByIdAsync(Obj.FoodID);
            if (food == null)
            {
                return 2;
            }
            var user = await _IUserRepon.GetByIdAsync(Obj.UserID);
            if (user == null)
            {
                return 3;
            }
            Reviews Reviews = new Reviews()
            {
                ID = Guid.NewGuid(),
                Content = Obj.Content,
                Rating = Obj.Rating,
                Created_At = DateTime.Now,
                Updated_At = DateTime.Now,
                FoodID = Obj.FoodID,
                UserID = Obj.UserID
            };
            if (await _IReviewsRepon.AddAsync(Reviews))
            {
                return 1;
            }
            return -1;
        }

        public async Task<Reviews> GetByIdAsync(Guid ID)
        {
            var data = await _IReviewsRepon.GetByIdAsync(ID);
            return data;
        }

        public async Task<List<Reviews>> GetReviewsAsync()
        {
            var data = await _IReviewsRepon.GetReviewsAsync();
            return data;
        }

        public async Task<int> RemoveAsync(Guid ID)
        {
            Reviews Reviews = await _IReviewsRepon.GetByIdAsync(ID);
            if (Reviews == null)
            {
                return 2;
            }
            if (await _IReviewsRepon.RemoveAsync(ID))
            {
                return 1;
            }
            return -1;
        }

        public async Task<int> UpdateAsync(Guid ID, CreateReviews Obj)
        {
            var food = await _IFoodRepon.GetByIdAsync(Obj.FoodID);
            if (food == null)
            {
                return 2;
            }
            var user = await _IUserRepon.GetByIdAsync(Obj.UserID);
            if (user == null)
            {
                return 3;
            }
            var reviews = await _IReviewsRepon.GetByIdAsync(ID);
            reviews.ID = ID;

            reviews.Content = Obj.Content;
            reviews.Rating = Obj.Rating;
            reviews.Created_At = Obj.Created_At;
            reviews.Updated_At = DateTime.Now;
            if (await _IReviewsRepon.UpdateAsync(reviews))
            {
                return 1;
            }
            return -1;
        }
    }
}
