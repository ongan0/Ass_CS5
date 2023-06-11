using _1_AppData._1_DataProcessing.Models;
using _1_AppData._2_Treatment.IReponsitorys;
using _1_AppData._2_Treatment.Reponsitorys;
using _2_AppApi._1_Treatment.IServices;
using _2_AppApi.ViewModels.User;

namespace _2_AppApi._1_Treatment.Services
{
    public class UserServices : IUserServices
    {
        IUserRepon _IUSerRepon;
        IRoleRepon _IRoleRepon;
        public UserServices()
        {
            _IUSerRepon = new UserRepon();
            _IRoleRepon = new RoleRepon();
        }
        public async Task<int> AddAsync(CreateUser Obj)
        {
            var role = await _IRoleRepon.GetByIdAsync(Obj.IDRole);
            if (role == null) { return 2; }


            var user = new User()
            {
                ID = Guid.NewGuid(),
                UserName = Obj.UserName,
                Password = Obj.Password,
                Name = Obj.Name,
                Email = Obj.Email,
                PhoneNumber = Obj.PhoneNumber,
                Description = Obj.Description,
                Status = Obj.Status,
                IDRole = Obj.IDRole
            };
            if (await _IUSerRepon.AddAsync(user))
            {
                return 1;
            }
            return 0;
        }


        public async Task<User> GetByIdAsync(Guid ID)
        {
            try
            {
                var data = await _IUSerRepon.GetByIdAsync(ID);
                return data;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<List<User>> GetUserAsync()
        {
            var data = _IUSerRepon.GetUserAsync();
            return data;
        }

        public async Task<int> RemoveAsync(Guid ID)
        {
            try
            {
                await _IUSerRepon.RemoveAsync(ID);
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public async Task<int> UpdateAsync(Guid ID, CreateUser Obj)
        {
            Role role = await _IRoleRepon.GetByIdAsync(Obj.IDRole);
            if (role == null)
            {
                return 2;
            }
            User user = await _IUSerRepon.GetByIdAsync(ID);
            user.ID = ID;
            user.UserName = Obj.UserName;
            user.Password = Obj.Password;
            user.Name = Obj.Name;
            user.Description = Obj.Description;
            user.Email = Obj.Email;
            user.PhoneNumber = Obj.PhoneNumber;
            user.Status = Obj.Status;
            user.IDRole = Obj.IDRole;
            if (await _IUSerRepon.UpdateAsync(user))
            {
                return 1;
            }
            return -1;

        }
    }
}
