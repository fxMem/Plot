using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlainValley.Plot.Core
{
    public class TextLine: Line
    {
        [JsonProperty("C")]
        public CharacteRef Character { get; set; }

        [JsonProperty("T")]
        public MultiLangText Text { get; set; }

        public TextLine()
        {
            Text = new MultiLangText();
        }

        internal override void Visit(LineVisiter visiter)
        {
            visiter.Visit(this);
        }
    }
}
