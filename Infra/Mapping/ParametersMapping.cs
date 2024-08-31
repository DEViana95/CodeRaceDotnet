using BaseApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaseApi.Infra.Data.Mapping
{
    public class ParametersMapping : IEntityTypeConfiguration<Parameters>
    {
        public void Configure(EntityTypeBuilder<Parameters> builder)
        {
            builder.ToTable("parameters");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                .HasColumnName("id");

            builder.Property(u => u.Cellphone)
                .HasColumnName("cellphone");

            builder.Property(u => u.AdministratorId)
                .HasColumnName("administrator_id");

            builder.Property(u => u.Phone)
                .HasColumnName("phone");
        }
    }
}