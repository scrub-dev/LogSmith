using NowPlaying.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace logsmith.ViewModels
{
    internal class MainWindowViewModel : ObservableObject
    {

        public RelayCommand? CloseApplicationCommand { get; set; }

        public MainWindowViewModel()
        {
            CloseApplicationCommand = new((o) => Application.Current.Shutdown());
        }
    }
}
