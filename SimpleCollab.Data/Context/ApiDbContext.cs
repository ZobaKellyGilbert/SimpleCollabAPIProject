using Microsoft.EntityFrameworkCore;
using SimpleCollab.Models.Entities;

namespace SimpleCollab.Data.Context
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(prop => prop.Address).IsRequired(false);
                entity.HasIndex(prop => prop.Email, $"IX_{nameof(User.Email)}").IsUnique(true);
                entity.HasIndex(prop => prop.Id, $"IX_{nameof(User.Id)}").IsUnique(true);
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
