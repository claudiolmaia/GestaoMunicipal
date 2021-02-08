using System;
using PPGM.Core.DomainObjects;

namespace PPGM.Core.Data
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}