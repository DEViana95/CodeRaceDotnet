using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaseApi.Infra.Mapping
{
    public class ReportDisasterMapping : IEntityTypeConfiguration<ReportDisaster>
    {
        public void Configure(EntityTypeBuilder<ReportDisaster> builder)
        {
            builder.ToTable("report_disaster");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                .HasColumnName("id");
            
            builder.Property(u => u.Lat)
                .HasColumnName("lat");

            builder.Property(u => u.Lng)
                .HasColumnName("lng");
            
            builder.Property(u => u.CellphoneNumber)
                .HasColumnName("cellphone_number");

            builder.Property(u => u.TxId)
                .HasColumnName("tx_id");

            builder.Property(u => u.Gravity)
                .HasColumnName("gravity");

            builder.Property(u => u.TypeId)
                .HasColumnName("type");

            builder.Property(u => u.Status)
                .HasColumnName("status");

            builder.Property(u => u.Created)
                .HasColumnName("created");

            builder.Property(u => u.Finish)
                .HasColumnName("finish");

            builder.Property(u => u.Motive)
                .HasColumnName("motive");
        }
    }
}