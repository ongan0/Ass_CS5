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
    public class OrderDetailRepon : IOrderDetailRepon
    {
        public readonly DBContext_Assgiment _context;
        public OrderDetailRepon(/*DBContext_Assgiment context*/)
        {
            _context = new DBContext_Assgiment();
        }
        public async Task<bool> AddAsync(OrderDetail obj)
        {
            try
            {
                _context.OrdelDetail.Add(obj);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public async Task<OrderDetail> GetByIdAsync(Guid ID)
        {
            try
            {
                var check = await _context.OrdelDetail.FindAsync(ID);
                return check;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<OrderDetail>> GetOrderDetailAsync()
        {
            try
            {
                var data = await _context.OrdelDetail.ToListAsync();
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
                var check = await _context.OrdelDetail.FindAsync(ID);
                if (check == null)
                {
                    return false;
                }
                _context.OrdelDetail.Remove(check);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> UpdateAsync(OrderDetail obj)
        {
            try
            {
                _context.OrdelDetail.UpdateRange(obj);
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
