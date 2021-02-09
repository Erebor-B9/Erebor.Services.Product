using System;
using System.Collections.Generic;
using System.Text;
using Erebor.Service.Product.SharedKernel.Interfaces;

namespace Erebor.Service.Product.SharedKernel
{
    public sealed class Courier
    {
        private readonly IServiceProvider _provider;

        public Courier(IServiceProvider provider)
        {
            _provider = provider;
        }

        public Result Deliver(ICommand command)
        {
            Type type = typeof(ICommandHandler<>);
            Type[] typeArgs = { command.GetType() };
            Type handlerType = type.MakeGenericType(typeArgs);

            dynamic handler = _provider.GetService(handlerType);
            Result result = handler.Handle((dynamic)command);

            return result;
        }
        public T Dispatch<T>(IQuery<T> query)
        {
            Type type = typeof(IQueryHandler<,>);
            Type[] typeArgs = { query.GetType(), typeof(T) };
            Type handlerType = type.MakeGenericType(typeArgs);

            dynamic handler = _provider.GetService(handlerType);
            T result = handler.Handle((dynamic)query);

            return result;
        }
    }
}
