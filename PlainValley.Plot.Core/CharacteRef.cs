using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlainValley.Plot.Core
{
    public class CharacteRef
    {
        [JsonProperty("C")]
        public EntityId CharacterId { get; set; }

        [JsonProperty("A")]
        public EntityId AliasId { get; set; }
    }
}
