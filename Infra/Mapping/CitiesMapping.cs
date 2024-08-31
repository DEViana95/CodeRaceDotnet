using BaseApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaseApi.Infra.Mapping
{
    public class CitiesMapping : IEntityTypeConfiguration<Cities>
    {
        public void Configure(EntityTypeBuilder<Cities> builder)
        {
            builder.ToTable("cities");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                .HasColumnName("id");

            builder.Property(u => u.Title)
                .HasColumnName("title");

            builder.Property(u => u.Lat)
                .HasColumnName("lat");

            builder.Property(u => u.Lng)
                .HasColumnName("lng");
        }
    }
}