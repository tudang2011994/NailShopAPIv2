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
        //public DbSet<CheckInWork> CheckInWorks { get; set; }

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
        }
    }
}
