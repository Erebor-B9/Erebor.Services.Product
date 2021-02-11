using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Erebor.Service.Product.SharedKernel.Interfaces
{
    public interface ICommand
    {
    }

    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        Task<Result> Handle(TCommand command);
    }

    public enum Result
    {
        UnSuccessful = 0,
        Successful = 1
    }
}
