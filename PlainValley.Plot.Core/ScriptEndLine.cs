using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlainValley.Plot.Core
{
    public class ScriptEndLine: Line
    {
        internal override void Visit(LineVisiter visiter)
        {
            visiter.Visit(this);
        }
    }
}
