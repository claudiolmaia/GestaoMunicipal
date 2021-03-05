using FluentValidation.Results;
using PPGM.Core.Messages;
using System.Threading.Tasks;

namespace PPGM.Core.Mediator
{
    public interface IMediatorHandler
    {
        Task PublicarEvento<T>(T evento) where T : Event;

        Task<ValidationResult> EnviarComando<T>(T comando) where T : Command;
    }
}