using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace WpfAndMVVM.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        private object _currentView;

        private HomeViewModel _homeViewModel { get; }

        private GameViewModel _gameViewModel { get; }

        public RelayCommand HomeViewCommand { get; set; }

        public RelayCommand GameViewCommand { get; set; }

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel(HomeViewModel homeViewModel,
            GameViewModel gameViewModel)
        {
            _homeViewModel = homeViewModel;
            _gameViewModel = gameViewModel;

            _currentView = _homeViewModel;

            HomeViewCommand = new RelayCommand(() =>
            {
                CurrentView = _homeViewModel;
            });

            GameViewCommand = new RelayCommand(() =>
            {
                CurrentView = _gameViewModel;
            });
        }
    }
}
