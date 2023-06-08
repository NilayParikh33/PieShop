using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SampleApplication2.Models
{
    public class MyPieShopDbContext : IdentityDbContext
    {
        public MyPieShopDbContext(DbContextOptions<MyPieShopDbContext> options) : base(options) 
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Pie> Pies { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}
