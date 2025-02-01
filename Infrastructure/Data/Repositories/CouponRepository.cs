using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces.Repositories;

namespace Infrastructure.Data.Repositories
{
    public class CouponRepository : ICouponRepository
    {
        private readonly MyAppDbContext _context;

        public CouponRepository(MyAppDbContext context)
        {
            _context = context;
        }

        public async Task addCouponAsync(Coupon coupon)
        {
            await _context.Coupons.AddAsync(coupon);
        }

        //public async Task<Coupon> getCouponByCodeAsync(string code)
        //{
        //    return await _context.Coupons.FirstOrDefaultAsync(c => c.Code == code);            
        //}

        public async Task saveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
