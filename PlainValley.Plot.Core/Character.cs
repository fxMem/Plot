using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlainValley.Plot.Core
{
    public class Character: Entity
    {
        [JsonProperty("AS")]
        public EntityCollection<CharacterAlias, CollectionOneIdFactory<CharacterAlias>> Aliases { get; set; }

        public Character()
        {
            Aliases = new EntityCollection<CharacterAlias, CollectionOneIdFactory<CharacterAlias>>();
        }
    }
}
