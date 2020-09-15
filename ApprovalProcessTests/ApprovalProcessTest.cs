using NUnit.Framework;
using ApprovalProcess.Models;
using System;
using System.ComponentModel;

namespace ApprovalProcessTests
{
    [TestFixture]
    public class Tests
    {
        private ApprovalStateMachine approvalWorkflow;

        [SetUp]
        public void Setup()
        {
            // To create a dynamic approval state machine it must be possible to define it at runtime by
            // adding states and transitions.
            approvalWorkflow = new ApprovalStateMachine();
            State initialState = new State("Initial");
            State reviewedState = new State("Reviewed");
            State approvedState = new State("Approved");
            approvalWorkflow.AddState(initialState);
            approvalWorkflow.AddState(reviewedState);
            approvalWorkflow.AddState(approvedState);
            Transition reviewerAccept = new Transition("ReviewerAccept", initialState, reviewedState);
            Transition approverAccept = new Transition("ApproverAccept", reviewedState, approvedState);
            approvalWorkflow.AddTransition(reviewerAccept);
            approvalWorkflow.AddTransition(approverAccept);
            approvalWorkflow.CurrentState = initialState;
        }

        [Test]
        public void A_New_ApprovalStateMachine_Should_Start_In_The_Initial_State()
        {
            Assert.AreEqual(approvalWorkflow.CurrentState.Name, "Initial");
        }

        [Test]
        public void An_Invalid_Transition_Should_Throw_InvalidTransitionException()
        {
            // state machine should be set up in initial state
            Assert.AreEqual(approvalWorkflow.CurrentState.Name, "Initial");
            // there should be no transition from Initial to Approved
            Assert.Throws<InvalidTransitionException>(() => approvalWorkflow.Transition("ApproverAccept"));
        }

        [Test]
        public void There_Should_Be_A_Path_From_Initial_To_Approved_States()
        {
            // state machine should be set up in initial state
            Assert.AreEqual(approvalWorkflow.CurrentState.Name, "Initial");
            approvalWorkflow.Transition("ReviewerAccept");
            approvalWorkflow.Transition("ApproverAccept");
            Assert.AreEqual(approvalWorkflow.CurrentState.Name, "Approved");
        }

    }
}