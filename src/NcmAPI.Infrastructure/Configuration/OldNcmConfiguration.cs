using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NcmAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NcmAPI.Infrastructure.Configuration
{
    public class OldNcmConfiguration : IEntityTypeConfiguration<OldNcm>
    {
        public void Configure(EntityTypeBuilder<OldNcm> builder)
        {
            builder.ToTable("old_ncm", schema: "dbo");
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).HasColumnName("id");
            builder.OwnsOne(o => o.Code, cb =>
            {
                cb.Property(c => c.Value).HasColumnName("code").IsRequired();
            });
            builder.HasMany(o => o.NewNcms)
                   .WithOne(n => n.OldNcm)
                   .HasForeignKey(n => n.OldId);
        }
    }
}
