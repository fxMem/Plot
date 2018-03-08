using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlainValley.Plot.Core
{
    public class MultiLangText
    {
        [JsonProperty("T")]
        public EntityRefDictionary<string> Texts { get; set; }

        public MultiLangText()
        {
            Texts = new EntityRefDictionary<string>();
        }

        public static MultiLangText Create(EntityId languageKey, string text)
        {
            var result = new MultiLangText();
            result.SetText(languageKey, text);
            return result;
        }

        public string GetTranslation(EntityId languageKey)
        {
            string result;
            Texts.TryGetValue(languageKey, out result);
            return result;
        }

        public void SetText(EntityId languageKey, string text)
        {
            Texts[languageKey] = text;
        }

        public string Get(EntityId languageKey)
        {
            if (!Texts.ContainsKey(languageKey))
            {
                return null;
            }

            return Texts[languageKey];
        }
    }
}
