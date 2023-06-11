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
    public class RoleRepon : IRoleRepon
    {
        public readonly DBContext_Assgiment _context;
        public RoleRepon(/*DBContext_Assgiment context*/)
        {
            _context = new DBContext_Assgiment();
        }
        public async Task<bool> AddAsync(Role obj)
        {
            try
            {
                _context.Roles.Add(obj);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public async Task<Role> GetByIdAsync(Guid ID)
        {
            try
            {
                var check = await _context.Roles.FindAsync(ID);
                return check;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Role>> GetRoleAsync()
        {
            try
            {
                var data = await _context.Roles.ToListAsync();
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
                var check = await _context.Roles.FindAsync(ID);
                if (check == null)
                {
                    return false;
                }
                _context.Roles.Remove(check);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> UpdateAsync(Role obj)
        {
            try
            {
                _context.Roles.UpdateRange(obj);
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
