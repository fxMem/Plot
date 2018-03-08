using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlainValley.Plot.Core
{
    public class Variable: Entity
    {
        [JsonProperty("V")]
        public string Value { get; set; }

        public bool Equals(string value)
        {
            return string.Equals(Value, value, StringComparison.OrdinalIgnoreCase);
        }
    }
}
