using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces.Repositories
{
    public interface ICouponRepository
    {
        Task addCouponAsync(Coupon coupon);
        //Task<Coupon> getCouponByCodeAsync(string code);
        Task saveChangesAsync();
    }
}
