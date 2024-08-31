using BaseApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaseApi.Infra.Data.Mapping
{
    public class IncidentTypesMapping : IEntityTypeConfiguration<IncidentTypes>
    {
        public void Configure(EntityTypeBuilder<IncidentTypes> builder)
        {
            builder.ToTable("incident_types");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                .HasColumnName("id");

            builder.Property(u => u.Title)
                .HasColumnName("title");

            builder.Property(u => u.Active)
                .HasColumnName("active");
        }
    }
}