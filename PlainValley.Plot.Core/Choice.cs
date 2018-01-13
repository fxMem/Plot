using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlainValley.Plot.Core
{
    public class Choice: Entity
    {
        public GoToLine TargetGoto { get; set; }

        public string VariableValue { get; set; }
    }
}
