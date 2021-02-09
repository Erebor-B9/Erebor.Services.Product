using System;
using System.Collections.Generic;
using System.Text;

namespace Erebor.Service.Product.SharedKernel.Interfaces
{
    public interface ICommand
    {
    }

    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        Result Handle(TCommand command);
    }

    public enum Result
    {
        UnSuccessful = 0,
        Successful = 1
    }
}
