using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlainValley.Plot.Core
{
    public class LineContext
    {
        private Player _player;

        public bool Skip { get; set; }

        public Progress Progress { get; set; }

        public LineContext(Player player, Progress progress)
        {
            _player = player;
            Progress = progress;
        }

        public void MoveToNextLine()
        {
            _player.MoveToNextLine();
        }

        public void MoveTo(GlobalLineId id)
        {
            _player.MoveTo(id);
        }
    }
}
