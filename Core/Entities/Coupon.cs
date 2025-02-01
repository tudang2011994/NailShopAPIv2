using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Coupon
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public decimal DiscountAmount { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool IsUsed { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
