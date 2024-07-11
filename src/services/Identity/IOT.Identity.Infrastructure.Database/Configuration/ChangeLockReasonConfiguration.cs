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
    internal sealed class ChangeLockReasonConfiguration : IEntityTypeConfiguration<ChangeLockReason>
    {
        public void Configure(EntityTypeBuilder<ChangeLockReason> builder)
        {
            builder.ToTable("ChangeLockReasons")
                .HasKey(x => x.Id);

            builder.Property(x => x.Message)
                .HasMaxLength(1080)
                .IsRequired();

            builder.Property(x => x.IsLockType)
                .IsRequired();

            builder.OwnsOne(x => x.CreateLog, y =>
            {
                y.Property(z => z.UserId).IsRequired();
                y.OwnsOne(z => z.Date, r =>
                {
                    r.Property(o => o.Miladi).IsRequired();
                    r.Property(o => o.Shamsi).HasMaxLength(14).IsRequired();
                    r.Property(o => o.Ghamari).HasMaxLength(14).IsRequired();
                });
            });

            builder.OwnsOne(x => x.DeleteLog, y =>
            {
                y.Property(z => z.UserId).HasDefaultValue(Guid.Empty);
                y.OwnsOne(z => z.Date, r =>
                {
                    r.Property(o => o.Miladi).IsRequired(false);
                    r.Property(o => o.Shamsi).HasMaxLength(14).IsRequired(false);
                    r.Property(o => o.Ghamari).HasMaxLength(14).IsRequired(false);
                });
            });
        }
    }
}
