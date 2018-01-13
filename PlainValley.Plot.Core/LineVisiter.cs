using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace PlainValley.Plot.Core
{
    public class LineVisiter
    {
        private ILineProcessor _processor;

        public LineVisiter(ILineProcessor processor)
        {
            _processor = processor;
        }

        public void Visit(Line line)
        {
            Trace.TraceInformation($"Processing line {line.Id} ({line.GetType().Name})");

            line.Visit(this);
        }

        public void Visit(TextLine line)
        {
            _processor.Process(line);
        }

        public void Visit(ChoiceLine line)
        {
            _processor.Process(line);
        }

        public void Visit(FinishChapterLine line)
        {
            _processor.Process(line);
        }

        public void Visit(ScriptEndLine line)
        {
            _processor.Process(line);
        }
    }
}
