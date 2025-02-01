using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string? Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool isRegisterUser { get; set; }
        public string Name { get; set; } // Added to match the full name field
        public int LoyaltyPoints { get; set; } // Added to include loyalty points
        public ICollection<LoyaltyPoint> LoyaltyPointsTransactions { get; set; } // Added to track loyalty points transactions
        public ICollection<Booking> Bookings { get; set; }
        public ICollection<Coupon> Coupons { get; set; } // Added to include coupons
        public string GoogleId { get; set; } // Added for Google login
    }

}
