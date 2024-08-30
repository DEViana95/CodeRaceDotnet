using BaseApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaseApi.Infra.Data.Mapping
{
    public class UsersMapping : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.ToTable("users");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                .HasColumnName("id");

            builder.Property(u => u.Login)
                .HasColumnName("login");

            builder.Property(u => u.Password)
                .HasColumnName("password");

            builder.Property(u => u.Type)
                .HasColumnName("type");
        }
    }
}