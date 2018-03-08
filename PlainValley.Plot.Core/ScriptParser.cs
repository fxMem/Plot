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
        private Dictionary<Type, string> _manualBindings = new Dictionary<Type, string>
        {
            { typeof(OneEntityId), "O" },
            { typeof(StringEntityId), "S" },
            { typeof(TextLine), "T" }
        };

        private Dictionary<string, Type> _manualBindingsRev = new Dictionary<string, Type>();

        public JsonBinder()
        {
            _manualBindingsRev = _manualBindings.ToDictionary(b => b.Value, b => b.Key);
        }

        public override void BindToName(Type serializedType, out string assemblyName, out string typeName)
        {
            assemblyName = null;
            if (_manualBindings.ContainsKey(serializedType))
            {
                typeName = _manualBindings[serializedType];
            }
            else
            {
                typeName = serializedType.FullName;
            }
        }

        public override Type BindToType(string assemblyName, string typeName)
        {
            if (_manualBindingsRev.ContainsKey(typeName))
            {
                return _manualBindingsRev[typeName];
            }

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
