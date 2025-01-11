using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace logsmith.Models
{
    class MainWindowModel
    {
        private readonly Dictionary<string, Type> _views = [];

        public MainWindowModel()
        {
            _views.Add("base", typeof(Views.BaseView));
        }
        private Type GetViewType(string s)
        {
            Type newType;
            return _views.TryGetValue(s, out newType!) ? newType : _views.First().Value;
        }
        public UserControl GetFrameContent(string frameName) => (UserControl)Activator.CreateInstance(GetViewType(frameName))! ?? new Views.BaseView();
    }
}
