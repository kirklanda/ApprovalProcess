using NUnit.Framework;
using ApprovalProcess.Models;
using System;

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

        [Test]
        public void A_Transition_From_Initial_State_To_Approved_State_Should_Throw_Exception()
        {
            ApprovalStateMachine approvalProcess = new ApprovalStateMachine();
            Assert.Throws<InvalidOperationException>(() => approvalProcess.Transition(ApprovalStates.Approved));
        }
    }
}