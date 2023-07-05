using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{

    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) 
            : base(options)
        {
            
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
