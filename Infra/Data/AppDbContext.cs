using BaseApi.Domain.Entities;
using BaseApi.Infra.Data.Mapping;
using BaseApi.Infra.Mapping;
using Microsoft.EntityFrameworkCore;

namespace BaseApi.Infra.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(
        DbContextOptions<AppDbContext> options
    ) : base(options)
    { }

    public DbSet<Cities> Cities { get; set; }
    public DbSet<Users> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CitiesMapping());
            modelBuilder.ApplyConfiguration(new UsersMapping());

            base.OnModelCreating(modelBuilder);
        }
}
