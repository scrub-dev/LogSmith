using logsmith.Utils.WeightedChance;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logsmith.TagParsers
{
    public class LogLevelParser : ITagParser
    {
        public enum LogLevel
        {
            INFO,WARN,LOG,ERR,FATAL
        }
        public static readonly string Tag = "loglevel";
        public (string parsedString, bool success) Parse(string parameterString)
        {
            string result = "";
            List<WeightedChanceParameter> weightedChanceParameters = [];
            foreach (KeyValuePair<string, int> entry in ParseParameters(parameterString))
            {
                weightedChanceParameters.Add(new WeightedChanceParameter(() => { result = entry.Key; }, entry.Value));
            }
            WeightedChanceExecutor.Execute(weightedChanceParameters);
            return (result, true);
        }

        public static Dictionary<string, int> ParseParameters(string parameterString)
        {
            if (parameterString.Length == 0 || parameterString == string.Empty || parameterString == null) return GetDefaultLogLevelDistrobution();
            else
            {
                Dictionary<string, int> parsedLogLevels = [];
                foreach (string item in parameterString[1..^1].Split(","))
                {
                    string[] x = item.Split(":");
                    parsedLogLevels.Add(x[0], int.Parse(x[1]));
                }
                return parsedLogLevels;
            }
        }

        public static Dictionary<string, int> GetDefaultLogLevelDistrobution()
        {
            Dictionary<string, int> x = [];
            foreach (LogLevel l in Enum.GetValues(typeof(LogLevel)))
            {
                x.Add(l.ToString(), (100 / Enum.GetValues(typeof(LogLevel)).Length));
            };
            return x;
        }
    }
}
