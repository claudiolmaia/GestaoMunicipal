using PPGM.Core.DomainObjects;
using System;

namespace PPGM.Core.Data
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}