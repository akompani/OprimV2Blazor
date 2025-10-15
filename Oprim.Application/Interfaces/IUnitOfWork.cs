using Oprim.Domain.Common;

namespace Oprim.Application.Interfaces;

public interface IUnitOfWork
{
    IGenericRepository<T> GenericRepository<T>() where T : BaseEntity;
}