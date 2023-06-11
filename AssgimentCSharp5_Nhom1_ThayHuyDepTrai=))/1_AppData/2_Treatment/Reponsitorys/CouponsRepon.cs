﻿using _1_AppData._1_DataProcessing.Context;
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
    public class CouponsRepon : ICouponsRepon
    {
        public readonly DBContext_Assgiment _context;
        public CouponsRepon(/*DBContext_Assgiment context*/)
        {
            _context = new DBContext_Assgiment();
        }
        public async Task<bool> AddAsync(Coupons obj)
        {
            try
            {
                _context.Coupons.Add(obj);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public async Task<Coupons> GetByIdAsync(Guid ID)
        {
            try
            {
                var check = await _context.Coupons.FindAsync(ID);
                return check;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Coupons>> GetCouponsAsync()
        {
            try
            {
                var data = await _context.Coupons.ToListAsync();
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
                var check = await _context.Coupons.FindAsync(ID);
                if (check == null)
                {
                    return false;
                }
                _context.Coupons.Remove(check);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> UpdateAsync(Coupons obj)
        {
            try
            {
                _context.Coupons.UpdateRange(obj);
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
