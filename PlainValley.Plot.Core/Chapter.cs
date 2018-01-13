using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlainValley.Plot.Core
{
    public class Chapter: Entity
    {
        public int Order { get; set; }

        public MultiLangText Title { get; set; }

        public EntityCollection<Block,CollectionOneIdFactory<Block>> Blocks { get; set; }

        public EntityId StartBlockId { get; set; }

        public Chapter()
        {
            Blocks = new EntityCollection<Block, CollectionOneIdFactory<Block>>();
            Title = new MultiLangText();
        }

        public Block AddEmptyBlock()
        {
            var newBlock = new Block();
            Blocks.Add(newBlock);

            if (StartBlockId == null)
            {
                StartBlockId = newBlock.Id;
            }

            return newBlock;
        }
    }
}
