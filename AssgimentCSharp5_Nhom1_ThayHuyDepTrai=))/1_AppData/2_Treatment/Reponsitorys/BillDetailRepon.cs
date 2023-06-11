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
    public class BillDetailRepon : IBillDetailRepon
    {
        public readonly DBContext_Assgiment _context;
        public BillDetailRepon(/*DBContext_Assgiment context*/)
        {
            _context = new DBContext_Assgiment();
        }
        public async Task<bool> AddAsync(BillDetail obj)
        {
            try
            {
                _context.BillDetails.Add(obj);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public async Task<BillDetail> GetByIdAsync(Guid ID)
        {
            try
            {
                var check = await _context.BillDetails.FindAsync(ID);
                return check;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<BillDetail>> GetBillDetailAsync()
        {
            try
            {
                var data = await _context.BillDetails.ToListAsync();
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
                var check = await _context.BillDetails.FindAsync(ID);
                if (check == null)
                {
                    return false;
                }
                _context.BillDetails.Remove(check);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> UpdateAsync(BillDetail obj)
        {
            try
            {
                _context.BillDetails.UpdateRange(obj);
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
