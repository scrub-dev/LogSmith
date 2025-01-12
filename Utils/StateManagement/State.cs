using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logsmith.Utils.StateManagement
{
    internal class State
    {
        public const string OFFLINE = "Not Running";
        public const string ONLINE = "Running";

        public const string FILE_ERROR = "Error writing to file";
        public const string FILE_ERROR_CLEAR = "Error clearing file";

        public const string PARSER_ERROR = "Template String failed to parse!";
        public const string PARSER_ERROR_UNKNOWN_TAG = "Unknown Template Tag";

        public const string SETTINGS_VALIDATION_FAILED = "Invalid Settings";
        public const string SETTINGS_VALIDATION_FAILED_INTERVAL_SHORT = "Write Interval too short";
        public const string SETTINGS_VALIDATION_FAILED_INTERVAL_LONG = "Write Interval too long";
    }
}
