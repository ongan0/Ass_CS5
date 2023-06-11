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
    public class CategoryRepon : ICategoryRepon
    {
        public readonly DBContext_Assgiment _context;
        public CategoryRepon(/*DBContext_Assgiment context*/)
        {
            _context = new DBContext_Assgiment();
        }
        public async Task<bool> AddAsync(Category obj)
        {
            try
            {
                _context.Categorys.Add(obj);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public async Task<Category> GetByIdAsync(Guid ID)
        {
            try
            {
                var check = await _context.Categorys.FindAsync(ID);
                return check;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Category>> GetCategoryAsync()
        {
            try
            {
                var data = await _context.Categorys.ToListAsync();
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
                var check = await _context.Categorys.FindAsync(ID);
                if (check == null)
                {
                    return false;
                }
                _context.Categorys.Remove(check);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> UpdateAsync(Category obj)
        {
            try
            {
                _context.Categorys.UpdateRange(obj);
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
