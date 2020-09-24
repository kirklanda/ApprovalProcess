using ApprovalProcess.Models;

namespace ApprovalProcessWebAPI
{
    public class ExampleApprovalProcess
    {
        public ApprovalStateMachine ApprovalWorkflow { get; }
        private static ExampleApprovalProcess instance = null;

        public static ExampleApprovalProcess GetInstance()
        {
            if(instance == null)        
            {
                instance = new ExampleApprovalProcess();
            }
            return instance;
        }


        private ExampleApprovalProcess()
        {
            ApprovalWorkflow = new ApprovalStateMachine();
            State initialState = new State("Initial");
            State reviewedState = new State("Reviewed");
            State endorsedState = new State("Endorsed");
            State approvedState = new State("Approved");
            State reviewerDeclinedState = new State("ReviewerDeclined", true);
            ApprovalWorkflow.AddState(initialState);
            ApprovalWorkflow.AddState(reviewedState);
            ApprovalWorkflow.AddState(endorsedState);
            ApprovalWorkflow.AddState(approvedState);
            ApprovalWorkflow.AddState(reviewerDeclinedState);
            Transition reviewerAccept = new Transition("ReviewerAccept", initialState, reviewedState);
            Transition endorserAccept = new Transition("EndorserAccept", reviewedState, endorsedState);
            Transition approverAccept = new Transition("ApproverAccept", endorsedState, approvedState);
            Transition reviewerDecline = new Transition("ReviewerDecline", initialState, reviewerDeclinedState);
            ApprovalWorkflow.AddTransition(reviewerAccept);
            ApprovalWorkflow.AddTransition(endorserAccept);
            ApprovalWorkflow.AddTransition(approverAccept);
            ApprovalWorkflow.AddTransition(reviewerDecline);
            ApprovalWorkflow.CurrentState = initialState;
        }
    }
}
