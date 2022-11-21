using CommunityToolkit.Mvvm.Input;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using WpfAndMVVM.Models;
using WpfAndMVVM.Repositories;
using WpfAndMVVM.Views;

namespace WpfAndMVVM.ViewModels
{
    public class GameViewModel
    {
        private readonly GameRepository _gameRepository;

        public ObservableCollection<GameItemViewModel> Games { get; set; }

        public IEnumerable<GameGenre> GameGenres { get; set; }

        public GameItemViewModel SelectedGame { get; set; }

        public GameItemViewModel NewGame { get; set; }

        public GameGenre SelectedGenre { get; set; }

        public RelayCommand AddCommand { get; set; }

        public GameViewModel(GameRepository gameRepository)
        {
            _gameRepository = gameRepository;

            AddCommand = new RelayCommand(DoAdd);
        }

        public void Load()
        {
            var games = _gameRepository.Get();
            Games = new ObservableCollection<GameItemViewModel>(
                games?.Select(game => new GameItemViewModel
                {
                    Id = game.Id,
                    Title = game.Title
                }));
        }

        private void DoAdd()
        {
            var newGameView = new NewGameView();

            var newGameViewModel = new NewGameViewModel();
            newGameView.DataContext = newGameViewModel;

            newGameView.ShowDialog();

            if (newGameView.DialogResult.HasValue && newGameView.DialogResult.Value)
            {
                var game = new Game(newGameViewModel.Title, newGameViewModel.Genre, newGameViewModel.ReleaseDate);
                _gameRepository.Add(game);

                Games.Add(new GameItemViewModel { Id = game.Id, Title = game.Title });
            }
        }

        public class GameItemViewModel
        {
            public int Id { get; set; }

            public string Title { get; set; }
        }
    }
}
