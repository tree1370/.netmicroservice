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

namespace IOT.Identity.Service.Token.Configuration
{
    internal sealed class RefreshTokenConfiguration : IEntityTypeConfiguration<UserRefreshToken>
    {
        public void Configure(EntityTypeBuilder<UserRefreshToken> builder)
        {

            builder.ToTable("UserRefreshTokens");
            builder.HasKey(s => s.Id);

            builder.Property(p => p.RefreshToken)
                  .HasMaxLength(128);

            //builder.OwnsOne(s => s.PhoneNumber, y =>
            //{
            //    //write Value Object Configuraion
            //    y.Property(e => e.CountryCode).HasMaxLength(500).IsRequired(false);
            //    y.Property(e => e.PhoneNumberWithOutCountryCode).HasMaxLength(128).IsRequired();
            //    y.Property(e => e.FullPhoneNumber).HasMaxLength(512).IsRequired();
            //});

            builder.OwnsOne(p => p.CreateDate, y =>
            {
                y.Property(e => e.Miladi).IsRequired();
                y.Property(e => e.Shamsi).HasMaxLength(14).IsRequired();
                y.Property(e => e.Ghamari).HasMaxLength(14).IsRequired();
            });

            builder.OwnsOne(p => p.ExpireDate, y =>
            {
                y.Property(e => e.Miladi).IsRequired();
                y.Property(e => e.Shamsi).HasMaxLength(14).IsRequired();
                y.Property(e => e.Ghamari).HasMaxLength(14).IsRequired();
            });
        }
    }
}