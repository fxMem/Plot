using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlainValley.Plot.Core
{
    public class Character: Entity
    {
        public MultiLangText CharacterName { get; set; }

        public Character()
        {
            CharacterName = new MultiLangText();
        }
    }
}
