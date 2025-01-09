using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace logsmith.TagParsers
{
    public class Parser
    {
        public static readonly string TagRegexString = @"{{\s*((?<tag>[a-z]*?)(?: (?<format>[0-9a-z\-\|\(\)\,\: ]*?))?)\s*}}";

        public static readonly  Dictionary<string, ITagParser> Parsers = new() { 
            { DateTagParser.Tag, new DateTagParser() },
            { LogLevelParser.Tag, new LogLevelParser() },
            { LoremIpsumParser.Tag, new LoremIpsumParser() }

        };

        public static void ParseTemplateString(ref string templateString)
        {
            while (Regex.IsMatch(templateString, TagRegexString, RegexOptions.IgnoreCase))
            {
                Match m = Regex.Match(templateString, TagRegexString, RegexOptions.IgnoreCase);
                (string parsedString, bool success) = ParseTag(m.Groups["tag"].Value, m.Groups["format"].Value);
                if (success)
                {
                    templateString = templateString.Remove(m.Index, m.Value.Length).Insert(m.Index, parsedString);
                }
            }
        }

        public static (string parsedString, bool success) ParseTag(string capturedTagName, string capturedTagParameters)
        {
            if (!Parsers.TryGetValue(capturedTagName, out ITagParser? parser)) return (string.Empty, false);
            return parser.Parse(capturedTagParameters ?? string.Empty);
        }
    }
}
