using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlainValley.Plot.Core
{
    public class PlayerContext
    {
        public EntityId CurrentLanguage { get; set; }

        public Progress Progress { get; set; }

        public ILineProcessor Processor { get; set; }

    }
}
