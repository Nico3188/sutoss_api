using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException()
        {
        }

        public BadRequestException(string message)
            : base(message)
        {
        }

        public BadRequestException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
