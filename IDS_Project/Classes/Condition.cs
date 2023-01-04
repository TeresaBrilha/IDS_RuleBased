using PacketDotNet;
using SharpPcap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDS_Project.Classes
{
    internal class Condition
    {
        public string LogicalOperator { get; set; }
        public List<Fact> Facts { get; set; }

        // Method to check if a packet matches this condition
        public bool IsMatch(RawCapture packet)
        {
            bool result = false;
            if (LogicalOperator == "all")
            {
                result = true;
                foreach (Fact fact in Facts)
                {
                    result = result && fact.IsMatch(packet);
                    if (!result)
                    {
                        break;
                    }
                }
            }
            else if (LogicalOperator == "any")
            {
                result = false;
                foreach (Fact fact in Facts)
                {
                    result = result || fact.IsMatch(packet);
                    if (result)
                    {
                        break;
                    }
                }
            }
            return result;
        }
    }
}
