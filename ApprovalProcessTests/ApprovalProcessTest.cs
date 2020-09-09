using NUnit.Framework;
using ApprovalProcess.Models;

namespace ApprovalProcessTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void A_New_ApprovalStateMachine_Should_Start_In_The_Initial_State()
        {
            ApprovalStateMachine approvalWorkflow = new ApprovalStateMachine();
            Assert.AreEqual(approvalWorkflow.State, ApprovalStates.Initial);
        }
    }
}