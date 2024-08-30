using BaseApi.Domain.Entities;
using BaseApi.Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace BaseApi.Infra.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(
        DbContextOptions<AppDbContext> options
    ) : base(options)
    { }

    public DbSet<Users> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Aplicar o mapeamento da entidade Users
            modelBuilder.ApplyConfiguration(new UsersMapping());

            // Outras configurações de mapeamento podem ser aplicadas aqui
            base.OnModelCreating(modelBuilder);
        }
}
