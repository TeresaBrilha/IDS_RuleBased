using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDS_Project.Classes
{
    public class RuleConverter : JsonConverter<Rule>
    {
        public override Rule ReadJson(JsonReader reader, Type objectType, Rule existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            // Load the JSON object from the reader.
            JObject jsonObject = JObject.Load(reader);

            // Create a new Rule object.
            Rule rule = new Rule();

            // Deserialize the JSON object into the Rule object.
            rule.Name = jsonObject["name"].ToObject<string>();
            rule.Priority = jsonObject["priority"].ToObject<int>();
            rule.Condition = jsonObject["condition"].ToObject<Condition>();
            rule.Actions = jsonObject["actions"].ToObject<List<Action>>();

            return rule;
        }

        public override void WriteJson(JsonWriter writer, Rule value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }

}
