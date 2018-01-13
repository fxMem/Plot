using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlainValley.Plot.Core
{
    [JsonArray]
    public class EntityDictionary<T> : Dictionary<EntityId, T>
        where T: Entity
    {

    }

    [JsonArray]
    public class EntityRefDictionary<T> : Dictionary<EntityId, T>
    {

    }
}
