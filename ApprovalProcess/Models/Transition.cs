using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApprovalProcess.Models
{
    public class Transition
    {
        public string Name { get; set; }
        public State From { get; set; }
        public State To { get; set; }
        public Transition(string name, State from, State to)
        {
            this.Name = name;
            this.From = from;
            this.To = to;
        }
    }
}
