using Microsoft.EntityFrameworkCore;
using System.Numerics;
using WebApplicationTest2.Entities;

namespace WebApplicationTest2.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Reservation_Service> Reservation_Services { get; set; }
        public DbSet<Service> Services { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Room>(entity =>
            {
                entity.HasKey(e => e.RoomId);
                entity.Property(e => e.RoomNumb).IsRequired().HasMaxLength(10);
                entity.Property(e => e.Type).IsRequired().HasMaxLength(50);
                entity.Property(e => e.PricePerNig).IsRequired().HasColumnType("decimal(10,2)");
                entity.Property(e => e.Floor).IsRequired();
            }
            );
            modelBuilder.Entity<Guest>(entity =>
            {
                entity.HasKey(e => e.GuestId);
                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.LastName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Phone).IsRequired().HasMaxLength(9);
            });
            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.HasKey(e =>e.ReservationId);
                entity.HasOne(e => e.Room).WithMany(r => r.Reservations).HasForeignKey(e => e.RoomId);
                entity.HasOne(e => e.Guest).WithMany(g => g.Reservations).HasForeignKey(e => e.GuestId);
                entity.Property(e => e.CheckInDate).IsRequired();
                entity.Property(e =>e.CheckOutDate); 
                entity.Property(e => e.Status).IsRequired().HasMaxLength(50);
            });
            modelBuilder.Entity<Reservation_Service>(entity =>
            {
                entity.HasKey(rs => new { rs.ServiceId, rs.ReservationId });
                entity.HasOne(e => e.Service).WithMany(s => s.Reservation_Services).HasForeignKey(e => e.ServiceId);
                entity.HasOne(e => e.Reservation).WithMany(r => r.Reservation_Services).HasForeignKey(e => e.ReservationId);
                entity.Property(e => e.Quantity).IsRequired();
                entity.Property(e => e.ServiceDate).IsRequired();
            }
            );
            modelBuilder.Entity<Service>(entity =>
            {
                entity.HasKey(e =>  e.ServiceId);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Description).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Price).IsRequired().HasColumnType("decimal(10,2)");
                entity.Property(e => e.DurationMinut).IsRequired();
            });
        }
    }
}
