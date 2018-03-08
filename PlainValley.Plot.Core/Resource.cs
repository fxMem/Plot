using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlainValley.Plot.Core
{
    public class Resource: Entity
    {
        [JsonProperty("V")]
        public MultiLangText Value { get; set; }

        public Resource()
        {
            Value = new MultiLangText();
        }
    }
}
