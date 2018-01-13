using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlainValley.Plot.Core
{
    public class Tag
    {
        public string Title { get; set; }

        public List<string> Parameters { get; set; }

        public EntityId ResourceId { get; set; }

        public Tag()
        {
            Parameters = new List<string>();
            ResourceId = new ResourceId();
        }
    }
}
