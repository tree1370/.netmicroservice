using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Building.Blocks.Application.Persistence;
using Building.Blocks.Core.Domain;
using IOT.Identity.Infrastructure.Database.Context;

namespace IOT.Identity.Infrastructure.Database.Repositories;

// Inherited from Ardalis.Specification's RepositoryBase<T>
public class ApplicationDbRepository<T> : RepositoryBase<T>, IReadRepository<T>, Building.Blocks.Application.Persistence.IRepository<T>
    where T : class, IAggregateRoot
{
    public ApplicationDbRepository(IdentityDbContext dbContext)
        : base(dbContext)
    {
    }

    // We override the default behavior when mapping to a dto.
    // We're using Mapster's ProjectToType here to immediately map the result from the database.
    // This is only done when no Selector is defined, so regular specifications with a selector also still work.
   
}