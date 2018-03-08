using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlainValley.Plot.Core
{
    public class GoToLine: UtilityLine
    {
        [JsonProperty("TR")]
        public GlobalLineId Target { get; set; }

        [JsonProperty("T")]
        public MultiLangText Text { get; set; }

        public GoToLine()
        {
            Text = new MultiLangText();
        }

        public override void Invoke(LineContext context)
        {
            base.Invoke(context);
            context.MoveTo(Target);
        }
    }
}
