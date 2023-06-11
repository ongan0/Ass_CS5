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
    public class ComboRepon : IComboRepon
    {
        public readonly DBContext_Assgiment _context;
        public ComboRepon(/*DBContext_Assgiment context*/)
        {
            _context = new DBContext_Assgiment();
        }
        public async Task<bool> AddAsync(Combo obj)
        {
            try
            {
                _context.Combos.Add(obj);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public async Task<Combo> GetByIdAsync(Guid ID)
        {
            try
            {
                var check = await _context.Combos.FindAsync(ID);
                return check;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Combo>> GetComboAsync()
        {
            try
            {
                var data = await _context.Combos.ToListAsync();
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
                var check = await _context.Combos.FindAsync(ID);
                if (check == null)
                {
                    return false;
                }
                _context.Combos.Remove(check);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> UpdateAsync(Combo obj)
        {
            try
            {
                _context.Combos.UpdateRange(obj);
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
