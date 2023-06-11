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
    public class Delivery_AddressRepon : IDelivery_AddressRepon
    {
        public readonly DBContext_Assgiment _context;
        public Delivery_AddressRepon(/*DBContext_Assgiment context*/)
        {
            _context = new DBContext_Assgiment();
        }
        public async Task<bool> AddAsync(Delivery_Address obj)
        {
            try
            {
                _context.Delivery_Addresses.Add(obj);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public async Task<Delivery_Address> GetByIdAsync(Guid ID)
        {
            try
            {
                var check = await _context.Delivery_Addresses.FindAsync(ID);
                return check;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Delivery_Address>> GetDelivery_AddressAsync()
        {
            try
            {
                var data = await _context.Delivery_Addresses.ToListAsync();
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
                var check = await _context.Delivery_Addresses.FindAsync(ID);
                if (check == null)
                {
                    return false;
                }
                _context.Delivery_Addresses.Remove(check);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> UpdateAsync(Delivery_Address obj)
        {
            try
            {
                _context.Delivery_Addresses.UpdateRange(obj);
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
