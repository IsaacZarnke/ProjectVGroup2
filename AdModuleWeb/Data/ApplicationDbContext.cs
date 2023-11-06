using Microsoft.EntityFrameworkCore;
using AdModuleWeb.Models;

namespace AdModuleWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        //this constructor is receing some DB context options which will be passed on to the base class (DbContext)
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
    }
}
