using _1_AppData._1_DataProcessing.Context;
using _1_AppData._1_DataProcessing.Models;
using _1_AppData._2_Treatment.IReponsitorys;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_AppData._2_Treatment.Reponsitorys
{
    public class UserRepon : IUserRepon
    {
        public readonly DBContext_Assgiment _context;
        public UserRepon()
        {
            _context = new DBContext_Assgiment();
        }
        public async Task<bool> AddAsync(User Obj)
        {
            try
            {
                _context.Users.Add(Obj);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<User> GetByIdAsync(Guid ID)
        {
            try
            {
                var data = await _context.Users.FindAsync(ID);
                return data;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<User>> GetUserAsync()
        {
            try
            {
                var data = await _context.Users.ToListAsync();
                return data;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> RemoveAsync(Guid ID)
        {
            try
            {
                var check = await _context.Users.FindAsync(ID);
                if (check == null)
                {
                    return false;
                }
                _context.Users.Remove(check);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> UpdateAsync(User Obj)
        {
            try
            {
                _context.Users.UpdateRange(Obj);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
