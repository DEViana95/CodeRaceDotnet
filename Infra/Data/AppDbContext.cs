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
    public DbSet<IncidentTypes> IncidentTypes { get; set; }
    public DbSet<Parameters> Parameters { get; set; }
    public DbSet<ReportDisaster> ReportDisaster { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Aplicar o mapeamento das entidade
            modelBuilder.ApplyConfiguration(new CitiesMapping());
            modelBuilder.ApplyConfiguration(new IncidentTypesMapping());
            modelBuilder.ApplyConfiguration(new ParametersMapping());
            modelBuilder.ApplyConfiguration(new ReportDisasterMapping());
            modelBuilder.ApplyConfiguration(new UsersMapping());

            base.OnModelCreating(modelBuilder);
        }
}
