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
    internal sealed class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.OwnsOne(x => x.DeleteLog, y =>
            {
                y.Property(z => z.UserId).HasDefaultValue(Guid.Empty);
                y.OwnsOne(z => z.Date, p =>
                {
                    p.Property(k => k.Miladi).IsRequired(false);
                    p.Property(k => k.Shamsi).HasMaxLength(14).IsRequired(false);
                    p.Property(k => k.Ghamari).HasMaxLength(14).IsRequired(false);
                });
                y.Property(z => z.IsDeleted).IsRequired();
            });

            builder.OwnsOne(x => x.CreateLog, y =>
            {
                y.Property(z => z.UserId).IsRequired();
                y.OwnsOne(z => z.Date, p =>
                {
                    p.Property(o => o.Miladi).IsRequired();
                    p.Property(o => o.Shamsi).HasMaxLength(14).IsRequired();
                    p.Property(o => o.Ghamari).HasMaxLength(14).IsRequired();
                });
            });
        }
    }
}
