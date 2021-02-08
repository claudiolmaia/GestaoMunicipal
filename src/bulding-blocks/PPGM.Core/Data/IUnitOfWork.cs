using System.Threading.Tasks;

namespace PPGM.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}