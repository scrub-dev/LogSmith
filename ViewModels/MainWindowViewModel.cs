using logsmith.Core;
using logsmith.Models;
using logsmith.Utils.StateManagement;
using System.Windows;
using System.Windows.Controls;

namespace logsmith.ViewModels
{
    internal class MainWindowViewModel : ObservableObject
    {

        public RelayCommand? CloseApplicationCommand { get; set; }
        public StateManager StateManager { get; set; }

        private readonly MainWindowModel mainWindowModel = new();
        public MainWindowViewModel()
        {
            StateManager = new StateManager(State.OFFLINE, (s) => CurrentState = s);
            CloseApplicationCommand = new((o) => Application.Current.Shutdown());
            SetFrameContent("base");
        }

        private string? _currentState;
        public string CurrentState { get => (_currentState is not null) ? _currentState : StateManager.GetDefaultState(); set { _currentState = value; OnPropertyChanged(); } }

        private UserControl? _currentView;
        public UserControl CurrentView { get => _currentView!; set { _currentView = value; OnPropertyChanged(); } }

        private void SetFrameContent(string newFrameName)
        {
            CurrentView = mainWindowModel.GetFrameContent(newFrameName);
        }
    }
}
