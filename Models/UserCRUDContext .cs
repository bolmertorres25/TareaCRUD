using Microsoft.EntityFrameworkCore;

namespace TareaCRUD.Models
{
    public class UserCRUDContext : DbContext
    {
        public UserCRUDContext(DbContextOptions<UserCRUDContext> options) : base(options)
        {
        }

        public DbSet<User> Client { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasIndex(c => c.Name).IsUnique();
        }

    }
}
