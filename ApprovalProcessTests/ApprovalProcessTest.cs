using NUnit.Framework;
using ApprovalProcess.Models;
using System;
using System.ComponentModel;
using System.Linq;
using System.Collections.Generic;

namespace ApprovalProcessTests
{
    [TestFixture]
    public class Tests
    {
        private ApprovalStateMachine approvalWorkflow;
        private MockApprovalAction approvalAction;

        [SetUp]
        public void Setup()
        {
            // To create a dynamic approval state machine it must be possible to define it at runtime by
            // adding states and transitions.
            approvalWorkflow = new ApprovalStateMachine();
            State initialState = new State("Initial");
            State reviewedState = new State("Reviewed");           
            State approvedState = new State("Approved");
            State reviewerDeclinedState = new State("ReviewerDeclined", true);
            approvalWorkflow.AddState(initialState);
            approvalWorkflow.AddState(reviewedState);
            approvalWorkflow.AddState(approvedState);
            approvalWorkflow.AddState(reviewerDeclinedState);
            Transition reviewerAccept = new Transition("ReviewerAccept", initialState, reviewedState);
            Transition approverAccept = new Transition("ApproverAccept", reviewedState, approvedState);
            Transition reviewerDecline = new Transition("ReviewerDecline", initialState, reviewerDeclinedState);
            approvalWorkflow.AddTransition(reviewerAccept);
            approvalWorkflow.AddTransition(approverAccept);
            approvalWorkflow.AddTransition(reviewerDecline);
            approvalWorkflow.CurrentState = initialState;

            approvalAction = new MockApprovalAction();
            approvedState.AddAction(approvalAction);

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

        [Test]
        public void If_A_Reviewer_Declines_Then_Approval_Process_Terminates()
        {
            // state machine needs to be in initial state
            Assert.AreEqual(approvalWorkflow.CurrentState.Name, "Initial");
            approvalWorkflow.Transition("ReviewerDecline");
            Assert.AreEqual(approvalWorkflow.CurrentState.Name, "ReviewerDeclined");
            Assert.AreEqual(approvalWorkflow.Terminated, true);
        }

        // In order to present the approval process via a user interface it must be
        // possible to get the next transitions that are possible.  These can then be
        // displayed to a user as options for them to select.
        [Test]
        public void State_Machine_Can_Return_Possible_Transitions_From_Current_State()
        {
            List<string> possibleTransitions;
            List<string> expectedTransitions = new List<string>{ "ReviewerAccept", "ReviewerDecline" };
            possibleTransitions = approvalWorkflow.PossibleTransitions();
            Assert.True(expectedTransitions.SequenceEqual(possibleTransitions));
        }

        // When the state machine enters a given state, e.g. Approved, it should fire a corresponding
        // action.
        [Test]
        public void When_State_Machine_Reaches_Approved_State_An_Action_Is_Triggered()
        {
            // state machine should be set up in initial state
            Assert.AreEqual(approvalWorkflow.CurrentState.Name, "Initial");
            approvalWorkflow.Transition("ReviewerAccept");
            approvalWorkflow.Transition("ApproverAccept");
            Assert.AreEqual(approvalWorkflow.CurrentState.Name, "Approved");
            Assert.IsTrue(approvalAction.IsFired);
        }
    }
}