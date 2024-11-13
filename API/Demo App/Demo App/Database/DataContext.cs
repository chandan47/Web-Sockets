using Demo_App.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo_App.Database
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Order> Order { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
    }

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.Entity<Appointment>().HasIndex(user => user.AppointmentId).IsUnique();
    //    modelBuilder.Entity<Order>().HasIndex(user => user.OrderId).IsUnique();
    //}
}
