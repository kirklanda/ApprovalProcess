using System;
using System.Collections.Generic;

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
        private Dictionary<string, State> states = new Dictionary<string, State>();
        private Dictionary<string, Transition> transitions = new Dictionary<string, Transition>();

        public State CurrentState { get; set; }
        public bool Terminated => CurrentState.TerminalState;
 

        public void AddState(State state)
        {
            this.states.TryAdd(state.Name, state);
        }

        public void AddTransition(Transition transition)
        {
            transitions.Add(transition.Name, transition);
        }

        public void Transition(string input)
        {
            if(transitions.TryGetValue(input, out Transition transition))
            {
                if(transition.From != this.CurrentState)
                {
                    throw new InvalidTransitionException("The transition " + transition.Name +
                        " is invalid from " + CurrentState);
                } else
                {
                    CurrentState = transition.To;
                }
            } else
            {
                throw new TransitionNotFoundException("Cannot find transition named " + input);
            }
        }

        public List<string> PossibleTransitions()
        {
            List<string> possibleTransitions = new List<string>();

            foreach(KeyValuePair<string, Transition> aTransition in transitions)
            {
                if(aTransition.Value.From == CurrentState)
                {
                    possibleTransitions.Add(aTransition.Value.Name);
                }
            }

            return possibleTransitions;
        }
    }
}
