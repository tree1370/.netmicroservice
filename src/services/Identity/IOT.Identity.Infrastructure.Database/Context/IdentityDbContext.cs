using Building.Blocks.Core.EFCore;
using IOT.Identity.Domain.Core;
using Microsoft.EntityFrameworkCore;

namespace IOT.Identity.Infrastructure.Database.Context
{
    public class IdentityDbContext : DbContext, IUnitOfWork
    {
        public IdentityDbContext(DbContextOptions options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(IdentityDbContext).Assembly);
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            var result = await base.SaveChangesAsync(cancellationToken);

            return true;
        }

        public DbSet<User> Users => Set<User>();
        public DbSet<UserRefreshToken> UserRefreshTokens => Set<UserRefreshToken>();
        public DbSet<Permission> Permission => Set<Permission>();
        public DbSet<Role> Role => Set<Role>();
        public DbSet<ChangeLockReason> ChangeLockReasons => Set<ChangeLockReason>();
    }
}
