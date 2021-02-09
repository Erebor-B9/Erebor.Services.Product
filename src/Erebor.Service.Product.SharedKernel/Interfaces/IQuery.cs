using System;
using System.Collections.Generic;
using System.Text;

namespace Erebor.Service.Product.SharedKernel.Interfaces
{
    public interface IQuery<TResult>
    {
    }

    public interface IQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {
        TResult Handle(TQuery query);
    }
}
