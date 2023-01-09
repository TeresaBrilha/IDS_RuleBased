using Json.Net;
using Newtonsoft.Json;
using PacketDotNet;
using SharpPcap;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IDS_Project.Classes
{
    [JsonObject]
    public class Rule
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("priority")]
        public int Priority { get; set; }
        [JsonProperty("condition")]
        public Condition Condition { get; set; }
        [JsonProperty("actions")]
        public List<Action> Actions { get; set; }

        public Condition Condition1
        {
            get => default;
            set
            {
            }
        }

        public Action Action
        {
            get => default;
            set
            {
            }
        }

        // Method to check if a packet matches this rule
        public bool IsMatch(RawCapture packet)
        {
            return Condition.IsMatch(packet);
        }
    }
}
