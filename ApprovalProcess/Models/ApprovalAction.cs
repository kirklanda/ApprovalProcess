using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApprovalProcess.Models
{
    public interface ApprovalAction
    {
        void Execute();

        bool IsFired { get; }
    }
}
