using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlainValley.Plot.Core
{
    public class ResourceId: EntityId
    {
        [JsonProperty("C")]
        public EntityId CollectionId { get; set; }

        [JsonProperty("R")]
        public EntityId ReferenceId { get; set; }

        protected override bool EqualsInternal(object obj)
        {
            var entity = obj as ResourceId;
            return entity.CollectionId == CollectionId && entity.ReferenceId == ReferenceId;
        }

        protected override int GetHashCodeInternal()
        {
            return (CollectionId?.GetHashCode() ?? 0) * 19 + ReferenceId.GetHashCode();
        }

        protected override string FormatIdString()
        {
            var collection = CollectionId as OneEntityId;
            var reference = ReferenceId as OneEntityId;
            if (collection != null && reference != null)
            {
                return $"{collection.Id};{reference.Id}";
            }

            return $"{CollectionId};{ReferenceId}";
        }
    }
}
