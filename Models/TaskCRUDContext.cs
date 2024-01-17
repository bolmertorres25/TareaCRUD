using Microsoft.EntityFrameworkCore;

namespace TareaCRUD.Models
{
    public class TaskCRUDContext : DbContext
    {
        public TaskCRUDContext(DbContextOptions<TaskCRUDContext> options) : base(options)
        {
        }

        public DbSet<Tack> Task { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);           
            modelBuilder.Entity<Tack>().HasIndex(c => c.title).IsUnique();           
        }
    }
}
