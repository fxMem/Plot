using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlainValley.Plot.Core
{
    public class Progress
    {
        public EntityId CurrentChapterId { get; set; }

        public EntityId CurrentBlockId { get; set; }

        public EntityId CurrentLineId { get; set; }

        public VariablesCollection Variables { get; set; }

        public Progress()
        {
            Variables = new VariablesCollection();
        }
    }
}
