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
    public class BillRepon : IBillRepon
    {
        public readonly DBContext_Assgiment _context;
        public BillRepon()
        {
            _context = new DBContext_Assgiment();
        }
        public async Task<bool> AddAsync(Bill obj)
        {
            try
            {
                _context.Bills.Add(obj);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public async Task<Bill> GetByIdAsync(Guid ID)
        {
            try
            {
                var check = await _context.Bills.FindAsync(ID);
                return check;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Bill>> GetBillAsync()
        {
            try
            {
                var data = await _context.Bills.ToListAsync();
                return data;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<bool> RemoveAsync(Bill Obj)
        {
            try
            {
                var check = await _context.Bills.FindAsync(Obj);
                if (check == null)
                {
                    return false;
                }
                _context.Bills.Remove(check);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> UpdateAsync(Bill obj)
        {
            try
            {
                _context.Bills.UpdateRange(obj);
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
