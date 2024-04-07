using Microsoft.EntityFrameworkCore;
using MouseYazilim.Models;

namespace MouseYazilim.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { 
            Users = Set<UserModel>(); 
        }
        public DbSet<UserModel> Users { get; set; }
    }
}
