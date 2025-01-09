using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace logsmith.TagParsers
{
    public class LoremIpsumParser : ITagParser
    {
        public static readonly string Tag = "loremipsum";
        private enum ParameterType {NUMBER, NUMBER_RANGE, BLANK}
        private static readonly string RangeRegex = @"^\((?<num1>[0-9]+?)\,(?<num2>[0-9]+?)\)$";
        private static readonly string Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";

        public (string parsedString, bool success) Parse(string parameterString)
        {
            ParameterType pType = GetParameterType(parameterString);
            string[] textArray = Text.Split(" ");


            string output = "";
            switch(pType)
            {
                case ParameterType.NUMBER:
                    output = string.Join(" ", new ArraySegment<string>(textArray, 0, int.Parse(parameterString)));
                    break;
                case ParameterType.NUMBER_RANGE:
                    output = string.Join(" ", new ArraySegment<string>(textArray, 0, GetNumBetweenRange(parameterString, textArray.Length + 1)));
                    break;
                case ParameterType.BLANK:
                    output = string.Join(" ", new ArraySegment<string>(textArray, 0, new Random().Next(textArray.Length + 1)));
                    break;
            }
            return (output, true);

        }

        private static ParameterType GetParameterType(string parameterString)
        {
            if (Regex.IsMatch(parameterString, RangeRegex)) return ParameterType.NUMBER_RANGE;
            if (parameterString.Length > 0) return ParameterType.NUMBER;
            return ParameterType.BLANK;
        }
        private static int GetNumBetweenRange(string parameterString, int maxPossibleLength)
        {
            Match m = Regex.Match(parameterString, RangeRegex);
            int _a = int.Parse(m.Groups["num1"].Value);
            int _b = int.Parse(m.Groups["num2"].Value);

            int a = Math.Min(_a, _b);
            int b = Math.Max(_a, _b);
            int c = Math.Min(b, maxPossibleLength);

            return new Random().Next(a,c);
        }
    }
}
