using System;

namespace Erebor.Service.Product.Domain.Exceptions
{
    public class BusinessException:Exception
    {
        public BusinessException(string exception):base(exception)
        {
        }
    }
}