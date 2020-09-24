using System;
using System.Collections.Generic;
using System.Text;
using ApprovalProcess.Models;

namespace ApprovalProcessTests
{
    class MockApprovalAction : ApprovalAction
    {
        public bool IsFired { get; private set; } 
        public void Execute()
        {
            IsFired = true;    
        }       
    }
}
