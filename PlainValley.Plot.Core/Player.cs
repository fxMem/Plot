using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlainValley.Plot.Core
{
    public class Player
    {
        private Script _script;
        private Progress _progress;
        private PlayerContext _context;
        private TextProcessor _textProcessor;
        private LineVisiter _lineVisiter;

        public EntityId CurrentChapterId
        {
            get
            {
                return _progress.CurrentChapterId;
            }
        }

        public Chapter CurrentChapter
        {
            get
            {
                return _script.Chapters.TryGetValue(_progress.CurrentChapterId);
            }
        }

        public Block CurrentBlock
        {
            get
            {
                return CurrentChapter?.Blocks.TryGetValue(_progress.CurrentBlockId);
            }
        }

        public Line CurrentLine
        {
            get
            {
                return CurrentBlock?.Lines.TryGetValue(_progress.CurrentLineId);
            }
        }

        public TextProcessor TextProcessor
        {
            get
            {
                return _textProcessor;
            }
        }

        public Player(Script script, PlayerContext context)
        {
            _script = script;
            _progress = context.Progress;
            _context = context;
            _textProcessor = new TextProcessor(_context);
            _lineVisiter = new LineVisiter(_context.Processor);

            Initialize();
        }

        public void Start()
        {
            TraceVerbose($"Started playing script {_script.InternalTitle}");
            ProcessLine();
        }

        public void MoveNext()
        {
            TraceVerbose("Moving next");

            InvokeInContext((c) =>
            {
                MoveToNextLine();
            });
            
            ProcessLine();
        }

        public void SelectChoice(EntityId choiceId)
        {
            TraceVerbose($"Selected choice with id = {choiceId.ToStringDebug()}");

            var choiceLine = CurrentLine as ChoiceLine;
            if (choiceLine == null)
            {
                throw new InvalidOperationException($"Can't select choice {choiceId.ToStringDebug()} cause current line {CurrentLine.Id.ToStringDebug()} is not choice line!");
            }

            InvokeInContext((c) =>
            {
                choiceLine.Select(choiceId, c);
            });

            ProcessLine();
        }

        private void InvokeInContext(Action<LineContext> action)
        {
            var context = GetLineContext();
            action(context);

            do
            {
                CurrentLine.Invoke(context);
            }
            while (context.Skip);
        }

        internal void MoveToNextLine()
        {
            var nextLine = CurrentBlock.GetNextLine(CurrentLine);
            TraceVerbose($"Internal: moving to next line {nextLine.Id.ToStringDebug()}");

            _progress.CurrentLineId = nextLine.Id;
        }

        internal void MoveTo(GlobalLineId id)
        {
            TraceVerbose($"Internal: moving to line {id.ToStringDebug()}");

            if (id.ChapterId != null)
            {
                var chapter = _script.Chapters[id.ChapterId];
                if (chapter == null)
                {
                    throw new ArgumentException($"Chapter with id = {id.ChapterId.ToStringDebug()} is not found!");
                }

                _progress.CurrentChapterId = chapter.Id;

                if (id.BlockId == null && id.LineId == null)
                {
                    // Move to Chapter
                    return;
                }
            }

            Block block = null;
            if (id.BlockId != null)
            {
                block = CurrentChapter.Blocks[id.BlockId];
                if (block == null)
                {
                    throw new ArgumentException($"Block with id = {id.ChapterId.ToStringDebug()} is not found in chapter {id.ChapterId}!");
                }

                _progress.CurrentBlockId = block.Id;
            }
            else
            {
                // If chapter was reset during prev. step, set up dirst block.
                if (id.ChapterId != null)
                {
                    _progress.CurrentBlockId = CurrentChapter.StartBlockId;
                }
            }

            Line line = null;
            if (id.LineId == null)
            {
                if (block == null)
                {
                    throw new InvalidOperationException($"Cannot move to target cause Block and Line not specified!");
                }

                line = block.GetFirstLine();
            }
            else
            {
                line = CurrentBlock.Lines[id.LineId];
            }
            
            if (line == null)
            {
                throw new ArgumentException($"Line with id = {id.LineId.ToStringDebug()} is not found in block {id.BlockId}, chapter = {id.ChapterId}!");
            }

            _progress.CurrentLineId = line.Id;
        }

        private void ProcessLine()
        {
            _lineVisiter.Visit(CurrentLine);
        }

        private void Initialize()
        {
            if (CurrentLine == null)
            {
                // Running script for the first time
                var chapter = _script.GetFirstChapter();
                if (chapter == null)
                {
                    throw new InvalidOperationException("Can't find first chapter!");
                }

                _progress.CurrentChapterId = chapter.Id;

                var block = chapter.Blocks[chapter.StartBlockId];
                if (block == null)
                {
                    throw new InvalidOperationException($"Start block with id = {chapter.StartBlockId.ToStringDebug()} is missing!");
                }

                _progress.CurrentBlockId = block.Id;

                var line = block.GetFirstLine();
                if (line == null)
                {
                    throw new InvalidOperationException($"Start line for block {chapter.StartBlockId.ToStringDebug()} is missing!");
                }

                _progress.CurrentLineId = line.Id;
            }
        }

        private LineContext GetLineContext()
        {
            return new LineContext(this, _progress);
        }

        private void TraceVerbose(string data)
        {
            Trace.TraceInformation(data);
        }
    }
}
