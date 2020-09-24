using System;
using System.Collections.Generic;

namespace ApprovalProcess.Models
{
    public class State
    {
        public string Name { get; set; }
        public bool TerminalState { get; }

        private List<ApprovalAction> actions = new List<ApprovalAction>();

        public void AddAction(ApprovalAction action)
        {
            actions.Add(action);
        }

        public void ExecuteActions()
        {
            actions.ForEach(action => { action.Execute(); });
        }

        public State(string name)
        {
            Name = name;
            TerminalState = false;
        }

        public State(string name, bool terminalState)
        {
            Name = name;
            TerminalState = terminalState;
        }
    }
}