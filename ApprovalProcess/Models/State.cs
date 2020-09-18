namespace ApprovalProcess.Models
{
    public class State
    {
        public string Name { get; set; }
        public bool TerminalState { get; }

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