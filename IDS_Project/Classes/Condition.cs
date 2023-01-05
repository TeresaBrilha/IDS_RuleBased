using Newtonsoft.Json;
using PacketDotNet;
using SharpPcap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDS_Project.Classes
{
    [JsonObject]
    public class Condition
    {
        [JsonProperty("logicalOperator")]
        public string LogicalOperator { get; set; }
        [JsonProperty("facts")]
        public List<Fact> Facts { get; set; }

        // Method to check if a packet matches this condition
        public bool IsMatch(RawCapture packet)
        {
            bool result = false;
            switch (LogicalOperator)
            {
                case "all":
                    result = Facts.All(fact => fact.IsMatch(packet));
                    break;
                case "any":
                    result = Facts.Any(fact => fact.IsMatch(packet));
                    break ;
            }
            return result;
        }
    }
}
