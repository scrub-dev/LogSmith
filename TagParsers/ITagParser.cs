using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logsmith.TagParsers
{
    public interface ITagParser
    {
        public static string Tag
        {
            get;
        }
       public (string parsedString, bool success) Parse(string parameterString);

    }
}
