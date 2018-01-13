using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlainValley.Plot.Core
{
    public interface ILineProcessor
    {
        void Process(TextLine line);

        void Process(ChoiceLine line);

        void Process(FinishChapterLine line);

        void Process(ScriptEndLine line);
    }
}
