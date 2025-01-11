using logsmith.Core;
using logsmith.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace logsmith.ViewModels
{
    internal class MainWindowViewModel : ObservableObject
    {

        public RelayCommand? CloseApplicationCommand { get; set; }


        private readonly MainWindowModel mainWindowModel = new();
        public MainWindowViewModel()
        {
            CloseApplicationCommand = new((o) => Application.Current.Shutdown());
            SetFrameContent("base");
        }

        private string? _currentState;
        public string CurrentState { get => (_currentState is not null) ? _currentState : "Not Running"; set { _currentState = value; OnPropertyChanged(); } }

        private UserControl? _currentView;
        public UserControl CurrentView { get => _currentView!; set { _currentView = value; OnPropertyChanged(); } }

        private void SetFrameContent(string newFrameName)
        {
            CurrentView = mainWindowModel.GetFrameContent(newFrameName);
        }
    }
}
