using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlainValley.Plot.Core
{
    public class Tag
    {
        [JsonProperty("T")]
        public string Title { get; set; }

        [JsonProperty("P")]
        public List<string> Parameters { get; set; }

        [JsonProperty("R")]
        public EntityId ResourceId { get; set; }

        public Tag()
        {
            Parameters = new List<string>();
            ResourceId = new ResourceId();
        }
    }
}
