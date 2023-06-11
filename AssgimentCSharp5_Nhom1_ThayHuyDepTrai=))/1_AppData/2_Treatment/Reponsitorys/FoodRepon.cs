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
    public class FoodRepon : IFoodRepon
    {
        public readonly DBContext_Assgiment _context;
        public FoodRepon(/*DBContext_Assgiment context*/)
        {
            _context = new DBContext_Assgiment();
        }
        public async Task<bool> AddAsync(Food obj)
        {
            try
            {
                _context.Foods.Add(obj);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public async Task<Food> GetByIdAsync(Guid ID)
        {
            try
            {
                var check = await _context.Foods.FindAsync(ID);
                return check;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<List<Food>> GetFoodAsync()
        {
            try
            {
                var data = await _context.Foods.ToListAsync();
                return data;
            }
            catch (Exception)
            {

                return null;
            }

        }


        public async Task<bool> RemoveAsync(Food obj)
        {
            try
            {

                _context.Foods.Remove(obj);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<bool> UpdateAsync(Food obj)
        {
            try
            {
                _context.Foods.UpdateRange(obj);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
