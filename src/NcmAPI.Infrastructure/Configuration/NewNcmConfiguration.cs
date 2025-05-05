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
    public class NewNcmConfiguration : IEntityTypeConfiguration<NewNcm>
    {
        public void Configure(EntityTypeBuilder<NewNcm> builder)
        {
            builder.ToTable("new_ncm");                // nome exato da tabela
            builder.HasKey(n => n.Id);
            builder.Property(n => n.Id).HasColumnName("id");
            builder.Property(n => n.OldId).HasColumnName("old_id");
            builder.OwnsOne(n => n.Code, cb =>
            {
                cb.Property(c => c.Value).HasColumnName("code").IsRequired();
            });
        }
    }
}
