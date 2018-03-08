using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlainValley.Plot.Core
{
    public class Line: Entity
    {
        [JsonProperty("O")]
        public int Order { get; set; }

        [JsonProperty("F")]
        public List<Tag> Tags { get; set; }

        public Line()
        {
            Tags = new List<Tag>();
        }

        public virtual void Invoke(LineContext context)
        {
            context.Skip = false;
        }

        internal virtual void Visit(LineVisiter visiter)
        {
            // overrride if needed
        }
    }
}
