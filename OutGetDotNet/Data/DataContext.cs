using Microsoft.EntityFrameworkCore;
using OutGetDotNet.Models;
using System.Diagnostics;

namespace OutGetDotNet.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Shipment> Shipments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Shipment>()
            .HasOne(x => x.Sender)
            .WithMany(x => x.SentShipments)
            .HasForeignKey(x => x.SenderId)
            .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Shipment>()
.HasOne(x => x.Receiver)
.WithMany(x => x.ReceivedShipments)
.HasForeignKey(x => x.ReceiverId)
.OnDelete(DeleteBehavior.ClientSetNull);
        }
    }

}
