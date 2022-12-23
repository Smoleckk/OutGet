using Microsoft.EntityFrameworkCore;
using OutGetDotNet.Models;

namespace OutGetDotNet.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
    }
}
