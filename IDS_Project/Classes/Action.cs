using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace IDS_Project.Classes
{
    [JsonObject]
    public class Action
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("parameters")]
        public Dictionary<string, object> Parameters { get; set; }

        // Method to execute this action
        public string Execute()
        {
            string message = string.Empty;
        // Add logic to execute the action here
            switch (Name)
            {
                case "alert":
                    message = "ALERT: " + (string)Parameters["message"] + "\n";
                    break;
            }
            return message;
        }
    }
}
