using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlainValley.Plot.Core
{
    public class Block: Entity
    {
        [JsonProperty("L")]
        public EntityCollection<Line, CollectionOneIdFactory<Line>> Lines { get; set; }

        public Block()
        {
            Lines = new EntityCollection<Line, CollectionOneIdFactory<Line>>();
        }

        public Line GetNextLine(Line line)
        {
            return Lines.FirstOrDefault(l => l.Order > line.Order);
        }

        public Line GetFirstLine()
        {
            return Lines.OrderBy(l => l.Order).FirstOrDefault();
        }

        public void AddLine(Line line)
        {
            line.Order = Lines.Count + 1;
            Lines.Add(line);
        }

        public void RemoveLine(EntityId id)
        {
            Lines.Remove(id);
        }
    }
}
