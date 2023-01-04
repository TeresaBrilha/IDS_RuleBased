using PacketDotNet;
using SharpPcap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDS_Project.Classes
{
    internal class Rule
    {
        public string Name { get; set; }
        public int Priority { get; set; }
        public Condition Condition { get; set; }
        public List<Action> Actions { get; set; }

        // Method to check if a packet matches this rule
        public bool IsMatch(RawCapture packet)
        {
            return Condition.IsMatch(packet);
        }
    }
}
