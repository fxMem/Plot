using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlainValley.Plot.Core
{
    public class Entity
    {
        [JsonProperty("I")]
        public EntityId Id { get; set; }

        [JsonProperty("N")]
        public string Name { get; set; }
    }
}
