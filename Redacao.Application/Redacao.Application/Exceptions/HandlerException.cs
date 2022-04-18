using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Application.Exceptions
{
    public class HandlerException : Exception
    {
        public HandlerException(string message)
        : base(message)
        {
        }

        public HandlerException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
