using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NextwoIdentity.Models;
using System.Reflection.Metadata;

namespace NextwoIdentity.Data
{
    public class NextwoDbContext:IdentityDbContext
    {
        public NextwoDbContext(DbContextOptions<NextwoDbContext> options) : base(options)
        {

        }


        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categorys { get; set; }
    }
}
