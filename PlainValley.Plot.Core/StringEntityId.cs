using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlainValley.Plot.Core
{
    public class StringEntityId: EntityId
    {
        [JsonProperty("N")]
        public string Name { get; set; }

        public StringEntityId()
        {

        }

        public StringEntityId(string name)
        {
            Name = name;
        }

        protected override bool EqualsInternal(object obj)
        {
            var id = obj as StringEntityId;
            return string.Equals(id.Name, Name, StringComparison.Ordinal);
        }

        protected override int GetHashCodeInternal()
        {
            return Name.GetHashCode();
        }

        protected override string FormatIdString()
        {
            return Name;
        }

        //public static explicit operator StringEntityId(string name)
        //{
        //    return new StringEntityId(name);
        //}
    }
}
