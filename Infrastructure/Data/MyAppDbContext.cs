using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Entities.JoinEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Data
{
    public class MyAppDbContext : DbContext
    {
        public MyAppDbContext(DbContextOptions<MyAppDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<StaffService> StaffServices { get; set; }

        public DbSet<Reward> Rewards { get; set; } // Added to include rewards
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<LoyaltyPoint> LoyaltyPoints { get; set; } // Added to include loyalty points


        //// In Infrastructure project
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite(
        //        configuration.GetConnectionString("DefaultConnection"),
        //        b => b.MigrationsAssembly("NailShopApi") // Replace with the project where you want migrations
        //    );
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            //One to Many User - Booking
            modelBuilder.Entity<Booking>().HasOne(b => b.User).WithMany(u => u.Bookings).HasForeignKey(b => b.UserId);
            //modelBuilder.Entity<Booking>().HasMany(b => b.CheckInWorks).WithOne(cw => cw.Booking).HasForeignKey(cw => cw.BookingId);

            //Many to Many Staff Service
            modelBuilder.Entity<StaffService>().HasKey(ss => new { ss.StaffId, ss.ServiceId });

            modelBuilder.Entity<StaffService>().HasOne(ss => ss.Staff).WithMany(s => s.StaffServices).HasForeignKey(ss => ss.StaffId);

            modelBuilder.Entity<StaffService>().HasOne(ss => ss.Service).WithMany(s => s.StaffServices).HasForeignKey(ss => ss.ServiceId);

            //One to Many CheckInWork - Booking - Staff - Service
            //modelBuilder.Entity<CheckInWork>().HasOne(cw => cw.Booking).WithMany(b => b.CheckInWorks).HasForeignKey(cw => cw.BookingId);
            modelBuilder.Entity<Booking>().HasOne(cw => cw.Service).WithMany(s => s.Bookings).HasForeignKey(cw => cw.ServiceId);
            modelBuilder.Entity<Booking>().HasOne(cw => cw.Staff).WithMany(s => s.Bookings).HasForeignKey(cw => cw.StaffId);

            // One to Many User - LoyaltyPoint
            modelBuilder.Entity<LoyaltyPoint>().HasOne(lp => lp.User).WithMany(u => u.LoyaltyPointsTransactions).HasForeignKey(lp => lp.UserId);



            // Seed initial data for Users
            //modelBuilder.Entity<User>().HasData(
            //    new User
            //    {
            //        Id = Guid.NewGuid(),
            //        Email = "john.doe@example.com",
            //        PhoneNumber = "1234567890",
            //        Name = "John Doe",
            //        Password = "password",
            //        isRegisterUser = true,
            //        LoyaltyPoints = 0
            //    },
            //    new User
            //    {
            //        Id = Guid.NewGuid(),
            //        Email = "jane.smith@example.com",
            //        PhoneNumber = "0987654321",
            //        Name = "Jane Smith",
            //        Password = "password",
            //        isRegisterUser = true,
            //        LoyaltyPoints = 0
            //    }
            //);

            //// Seed initial data for Services
            //modelBuilder.Entity<Service>().HasData(
            //    new Service
            //    {
            //        Id = 1,
            //        ServiceName = "Manicure",
            //        Amount = 20.0f,
            //        IsValid = true,
            //        Duration = 30.0f
            //    },
            //    new Service
            //    {
            //        Id = 2,
            //        ServiceName = "Pedicure",
            //        Amount = 25.0f,
            //        IsValid = true,
            //        Duration = 45.0f
            //    }
            //);

            //// Seed initial data for Staff
            //modelBuilder.Entity<Staff>().HasData(
            //    new Staff
            //    {
            //        Id = 1,
            //        Name = "Alice",
            //        WorkingDay = "MTWHFSU"
            //    },
            //    new Staff
            //    {
            //        Id = 2,
            //        Name = "Bob",
            //        WorkingDay = "MT_HF_U"
            //    }
            //);

            //// Seed initial data for StaffService (linking Staff and Service)
            //modelBuilder.Entity<StaffService>().HasData(
            //    new StaffService
            //    {
            //        StaffId = 1,
            //        ServiceId = 1
            //    },
            //    new StaffService
            //    {
            //        StaffId = 1,
            //        ServiceId = 2
            //    },
            //    new StaffService
            //    {
            //        StaffId = 2,
            //        ServiceId = 1
            //    }
            //);

            //// Seed initial data for Rewards
            //modelBuilder.Entity<Reward>().HasData(
            //    new Reward
            //    {
            //        Id = Guid.NewGuid(),
            //        Name = "Free Service",
            //        RequiredPoints = 100,
            //        Description = "Get a free service when you reach 100 points."
            //    },
            //    new Reward
            //    {
            //        Id = Guid.NewGuid(),
            //        Name = "Discount Voucher",
            //        RequiredPoints = 50,
            //        Description = "Get a $10 discount voucher when you reach 50 points."
            //    }
            //);
        }
    }
}
