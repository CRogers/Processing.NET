using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Processing.NET
{
    public class ProcessingException : ApplicationException
    {
        public ProcessingException()
        {
        }

        public ProcessingException(string message) : base(message)
        {
        }

        public ProcessingException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
