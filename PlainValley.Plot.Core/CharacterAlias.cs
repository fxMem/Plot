using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlainValley.Plot.Core
{
    public class CharacterAlias: Entity
    {
        [JsonProperty("T")]
        public MultiLangText Title { get; set; }

        [JsonProperty("S")]
        public ResourceId SpriteId { get; set; }

        public CharacterAlias()
        {
            Title = new MultiLangText();
            SpriteId = new ResourceId();
        }
    }
}
