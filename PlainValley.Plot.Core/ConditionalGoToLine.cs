using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlainValley.Plot.Core
{
    public class ConditionalGoToLine: UtilityLine
    {
        [JsonProperty("VR")]
        public EntityId Variable { get; set; }

        [JsonProperty("VL")]
        public string Value { get; set; }

        [JsonProperty("T")]
        public GlobalLineId Target { get; set; }

        public override void Invoke(LineContext context)
        {
            base.Invoke(context);
            var variable = context.Progress.Variables[Variable];
            if (variable.Equals(Value))
            {
                context.MoveTo(Target);
            }
        }
    }
}
