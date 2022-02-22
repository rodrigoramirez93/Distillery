using Microsoft.EntityFrameworkCore;

namespace Domain
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new List<User>()
            {
                new User(){ Id = 1, Username = "test", Password = "test" },
            });
        }

        public DbSet<Card>? Cards { get; set; }
        public DbSet<User>? Users { get; set; }
    }
}