using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlainValley.Plot.Core
{
    public class OneEntityId : EntityId
    {
        [JsonProperty("I")]
        public double Id { get; set; }

        protected override bool EqualsInternal(object obj)
        {
            var entity = obj as OneEntityId;
            return entity.Id == Id;
        }

        protected override int GetHashCodeInternal()
        {
            return Id.ToString().GetHashCode();
        }

        protected override string FormatIdString()
        {
            return Id.ToString();
        }
    }
}
