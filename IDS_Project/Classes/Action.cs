using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDS_Project.Classes
{
    internal class Action
    {
        public string Name { get; set; }
        public Dictionary<string, object> Params { get; set; }

        // Method to execute this action
        public void Execute()
        {
            // Add logic to execute the action here
            switch (Name)
            {
                case "alert":
                    string message = (string)Params["message"];
                    Console.WriteLine("ALERT: " + message);
                    break;
            }
        }
    }
}
