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
        public static readonly string TagRegexString = @"{{\s*((?<tag>[a-z]*?)(?: (?<format>[a-z\-\|\(\)\,]*?))?)\s*}}";
        public static readonly Regex TagRegex = new(TagRegexString, RegexOptions.IgnoreCase);


        public static readonly  Dictionary<string, ITagParser> parsers = new() { 
            { DateTagParser.Tag, new DateTagParser() },
            { LogLevelParser.Tag, new LogLevelParser() }
        };

        public static void ParseTemplateString(ref string templateString)
        {
            
            foreach (Match m in Regex.Matches(templateString, TagRegexString).Cast<Match>())
            {
                // get match index 
                // get match length
                // generate parsed tag from match
                // remove match index + length
                // splice generated parsed tag.
                Trace.WriteLine(string.Format("Found '{0}' at position {1} with length {2}", m.Value, m.Index, m.Value.Length));
                Trace.WriteLine(string.Format("Tag : {0} | Format : {1}", m.Groups["tag"], m.Groups["format"]));
            }
        }

        public static (string parsedString, bool success) ParseTag(string capturedTagName, string capturedTagParameters)
        {
            if (!parsers.TryGetValue(capturedTagName, out ITagParser? parser)) throw new Exception("Tag Parser not found"); // TODO : Set a UI Error instead.
            return parser.Parse(capturedTagParameters ?? string.Empty);
        }
    }
}
