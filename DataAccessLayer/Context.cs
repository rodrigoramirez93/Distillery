using Domain;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class Context : DbContext
    {
        public Context()
        {

        }

        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<Card>? Cards { get; set; }
    }
}