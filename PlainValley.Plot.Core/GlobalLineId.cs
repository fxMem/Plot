using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlainValley.Plot.Core
{
    public class GlobalLineId: EntityId
    {
        public EntityId ChapterId { get; set; }

        public EntityId BlockId { get; set; }

        public EntityId LineId { get; set; }

        protected override bool EqualsInternal(object obj)
        {
            var entity = obj as GlobalLineId;
            return entity.ChapterId == ChapterId && entity.BlockId == BlockId && entity.LineId == LineId;
        }

        protected override int GetHashCodeInternal()
        {
            return (ChapterId?.GetHashCode() ?? 0) * 19 + BlockId.GetHashCode() * 7 + LineId.GetHashCode();
        }

        protected override string FormatIdString()
        {
            var chapter = ChapterId as OneEntityId;
            var block = BlockId as OneEntityId;
            var line = LineId as OneEntityId;
            if (chapter != null && block != null && line != null)
            {
                return $"{chapter.Id};{block.Id};{line.Id}";
            }

            return $"{ChapterId};{BlockId};{LineId}";
        }
    }
}
