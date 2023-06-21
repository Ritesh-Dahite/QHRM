using QHRM.Models;
using Microsoft.EntityFrameworkCore;

namespace QHRM.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<ProductInfo> Products { get; set; }
    }
}