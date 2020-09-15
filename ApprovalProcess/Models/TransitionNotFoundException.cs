using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApprovalProcess.Models
{
    public class TransitionNotFoundException : Exception
    {
        public TransitionNotFoundException() { }

        public TransitionNotFoundException(string message)
            : base(message) { }

        public TransitionNotFoundException(string message, Exception inner)
            : base(message, inner) { }
    }
}
