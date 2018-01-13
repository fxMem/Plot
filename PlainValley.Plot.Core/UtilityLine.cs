using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlainValley.Plot.Core
{
    public class UtilityLine: Line
    {
        public override void Invoke(LineContext context)
        {
            context.Skip = true;
        }
    }
}
