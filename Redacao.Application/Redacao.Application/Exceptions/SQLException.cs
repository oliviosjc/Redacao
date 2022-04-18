using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Application.Exceptions
{
    public class SQLException : Exception
    {
        public SQLException(string message)
        : base(message)
        {
        }

        public SQLException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
