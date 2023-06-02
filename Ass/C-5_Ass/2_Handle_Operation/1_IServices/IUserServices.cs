using Assignment_CS5_Share._1_Models;

namespace Assignment_Chsarp5_datntph19899._2_Handle_Operation._1_IServices
{
    public interface IUserServices
    {
        Task<List<User>> GetUsersAsync();
        Task<User> GetUserByIdAsync(Guid id);
        Task<Guid> AddUserAsync(User user);
        Task<bool> UpdateUserAsync(User user);
        Task<bool> DeleteUserAsync(Guid id);
    }
}
