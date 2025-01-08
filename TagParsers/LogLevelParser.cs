using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logsmith.TagParsers
{
    public class LogLevelParser : ITagParser
    {
        public static readonly string Tag = "loglevel";
        public (string parsedString, bool success) Parse(string parameterString)
        {
            return ("helloworld", true);
        }
    }
}
