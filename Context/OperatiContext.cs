using Microsoft.EntityFrameworkCore;
using OperatiAPI.Models;

namespace OperatiAPI.Context
{
    public class OperatiContext : DbContext
    {
        public OperatiContext(DbContextOptions options)
            : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
    }
}
