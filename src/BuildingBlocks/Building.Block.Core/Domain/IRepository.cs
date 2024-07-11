using Building.Blocks.Core.EFCore;

namespace Building.Blocks.Core.Domain;

public interface IRepository<T> where T : IAggregateRoot
{
    IUnitOfWork UnitOfWork { get; }
}
