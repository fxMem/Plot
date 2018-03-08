using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlainValley.Plot.Core
{
    public class Choice: Entity
    {
        [JsonProperty("GT")]
        public GoToLine TargetGoto { get; set; }

        [JsonProperty("VV")]
        public string VariableValue { get; set; }
    }
}
