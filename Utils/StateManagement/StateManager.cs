using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logsmith.Utils.StateManagement
{

    class StateManager
    {
        private readonly Action<string> _action;
        public static string GetDefaultState()
        {
            return State.OFFLINE;
        }
        public StateManager(string initialState, Action<string>cb) 
        {
            _action = cb;
            _action.Invoke(initialState);
        }
        public void UpdateState(string stateEnum)
        {
            _action.Invoke(stateEnum);
        }
    }
}
