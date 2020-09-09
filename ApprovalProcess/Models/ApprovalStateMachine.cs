using System;

namespace ApprovalProcess.Models
{
    public enum ApprovalStates
    {
        Initial,
        Reviewed,
        Endorsed,
        Approved
    }

    /**
     * Maintains the state of an approval and the possible transitions between states.  For example, users can review, 
     * endorse and finally approve work in progress.  Once approval has occured further downstream processing can occur.
    */
    public class ApprovalStateMachine
    {
        public ApprovalStates State { get; set; }

        public void Transition(ApprovalStates toState)
        {
            // TODO: Generalise the rules for valid and invalid transitions between states
            if(this.State == ApprovalStates.Initial && toState != ApprovalStates.Reviewed)
            {
                throw new InvalidOperationException("Must move from Initial state to Reviewed state");
            }

            this.State = toState;
        }
    }
}
