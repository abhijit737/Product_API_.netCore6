using ProductCRUDWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ProductCRUDWebAPI.Data
{
    

    public class ProductDBContext : DbContext
    {
        public ProductDBContext(DbContextOptions<ProductDBContext> options) : base(options)
        {
        }

    public DbSet<Product> Products { get; set; }


     }

}
