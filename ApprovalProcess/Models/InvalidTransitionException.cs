using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApprovalProcess.Models
{
    public class InvalidTransitionException : Exception
    {
        public InvalidTransitionException() { }

        public InvalidTransitionException(string message)
            : base(message) { }

        public InvalidTransitionException(string message, Exception inner)
            : base(message, inner) { }
    }
}
