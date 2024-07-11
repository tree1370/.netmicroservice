using IOT.Identity.Domain.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Identity.Infrastructure.Database.Configuration
{
    internal sealed class PermissionConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.HasKey(x => x.Id);

            builder.OwnsOne(x => x.DeleteLog, y =>
            {
                y.Property(z => z.UserId).HasDefaultValue(Guid.Empty);
                y.OwnsOne(z => z.Date, o =>
                {
                    o.Property(p => p.Miladi).IsRequired(false);
                    o.Property(p => p.Shamsi).HasMaxLength(14).IsRequired(false);
                    o.Property(p => p.Ghamari).HasMaxLength(14).IsRequired(false);
                });
                y.Property(z => z.IsDeleted).IsRequired();
            });

            builder.OwnsOne(x => x.CreateLog, y =>
            {
                y.Property(z => z.UserId).IsRequired();
                y.OwnsOne(z => z.Date, o =>
                {
                    o.Property(p => p.Miladi).IsRequired();
                    o.Property(p => p.Shamsi).HasMaxLength(14).IsRequired();
                    o.Property(p => p.Ghamari).HasMaxLength(14).IsRequired();
                });
            });
        }
    }
}
