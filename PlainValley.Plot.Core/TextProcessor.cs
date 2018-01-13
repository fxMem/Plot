using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PlainValley.Plot.Core
{
    public class TextProcessor
    {
        private PlayerContext _context;
        private Regex _variablesRegex = new Regex(@"\{\s*(?'name'\w+)\s*\}", RegexOptions.IgnoreCase | RegexOptions.Compiled);

        public TextProcessor(PlayerContext context)
        {
            _context = context;
        }

        public string GetText(MultiLangText text, EntityId linkedObjectId = null)
        {
            var translation = text.GetTranslation(_context.CurrentLanguage);
            if (translation == null)
            {
                throw new InvalidOperationException($"Translation not found for selected language {_context.CurrentLanguage}, linked object = {linkedObjectId.ToString() ?? "UNKNOWN"}");
            }

            return GetFilledString(translation);
        }

        private string GetFilledString(string text)
        {
            var result =_variablesRegex.Replace(text, (m) =>
            {
                var varName = m.Groups["name"].Value;
                var variable = _context.Progress.Variables[new StringEntityId(varName)];
                var variableValue = GetFilledString(variable.Value);
                return variableValue;
            });

            return result;
        }
    }
}
