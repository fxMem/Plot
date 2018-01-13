using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlainValley.Plot.Core
{
    public class ScriptVersion
    {
        public int Major { get; set; }

        public int Minor { get; set; }

        public string DatePart { get; set; }

        public ScriptVersion()
        {
            Major = 0;
            Minor = 1;

            DatePart = DateTime.Now.ToString("yyyyMMddhhmmss");
        }

        public ScriptVersion IncreaseMinor()
        {
            var next = new ScriptVersion();
            next.Minor++;

            return next;
        }
    }
}
