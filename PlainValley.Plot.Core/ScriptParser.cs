using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PlainValley.Plot.Core
{
    class JsonBinder : SerializationBinder
    {
        public override void BindToName(Type serializedType, out string assemblyName, out string typeName)
        {
            assemblyName = null;
            typeName = serializedType.FullName;
        }

        public override Type BindToType(string assemblyName, string typeName)
        {
            return typeof(Script).Assembly.GetType(typeName);
        }
    }

    public class ScriptParser
    {
        private JsonSerializerSettings _settings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            TypeNameHandling = TypeNameHandling.Auto,
            Binder = new JsonBinder(),
            Formatting = Formatting.Indented
        };

        public Script Parse(string raw)
        {
            return JsonConvert.DeserializeObject<Script>(raw, _settings);
        }
    }
}
