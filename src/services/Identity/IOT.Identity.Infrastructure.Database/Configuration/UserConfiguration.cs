using Building.Blocks.Core.Domain.ValueObjects;
using IOT.Identity.Domain.Core;
using IOT.Identity.Service.User.ValueObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Identity.Infrastructure.Database.Configuration
{
    internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder.ToTable("users", "User");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
            .HasConversion(
                v => v.Value,
                v => new UserId(v));

            //builder.Property(e => e.UserName)
            //.HasMaxLength(128).IsRequired();


            builder.OwnsOne(s => s.Email, y =>
            {
                //write Value Object Configuraion
                y.Property(e => e.Value).HasMaxLength(500).IsRequired(false);
            });

            builder.OwnsOne(s => s.PhoneNumber, y =>
            {
                //write Value Object Configuraion
                y.Property(e => e.CountryCode).HasMaxLength(500).IsRequired(false);
                y.Property(e => e.PhoneNumberWithOutCountryCode).HasMaxLength(128).IsRequired();
            });


            builder.OwnsOne(s => s.UserNameInfo, y =>
            {
                //write Value Object Configuraion
                y.Property(e => e.FirstName).HasMaxLength(120).IsRequired();
                y.Property(e => e.LastName).HasMaxLength(120).IsRequired();

                y.OwnsOne(x => x.BirthDate, e =>
                {
                    e.Property(z => z.Miladi).IsRequired();
                    e.Property(z => z.Shamsi).HasMaxLength(14).IsRequired();
                    e.Property(z => z.Ghamari).HasMaxLength(14).IsRequired();
                });
            });

            builder.OwnsOne(s => s.RegisterDate , y =>
            {
                y.Property(e => e.Miladi).IsRequired();
                y.Property(e => e.Shamsi).HasMaxLength(14).IsRequired();
                y.Property(e => e.Ghamari).HasMaxLength(14).IsRequired();
            });

            builder.OwnsOne(s => s.LastLoginDate , y =>
            {
                y.Property(e => e.Miladi).IsRequired(false);
                y.Property(e => e.Shamsi).HasMaxLength(14).IsRequired(false);
                y.Property(e => e.Ghamari).HasMaxLength(14).IsRequired(false);
            });

            builder.OwnsOne(s => s.LockExpireDate, y =>
            {
                y.Property(e => e.Miladi).IsRequired(false);
                y.Property(e => e.Shamsi).HasMaxLength(14).IsRequired(false);
                y.Property(e => e.Ghamari).HasMaxLength(14).IsRequired(false);
            });

            builder.HasOne<UserRefreshToken>(p => p.RefreshToken).
                WithOne(p=>p.User).HasForeignKey<UserRefreshToken>(p => p.UserId);


            builder.HasOne(p => p.ChangeLockReason)
                .WithMany().HasForeignKey(p => p.LockReason_Id).IsRequired(false);

        }
    }

  
}
