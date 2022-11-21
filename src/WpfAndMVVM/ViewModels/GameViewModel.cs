using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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

        public RelayCommand EditCommand { get; set; }

        public RelayCommand DeleteCommand { get; set; }

        public GameViewModel(GameRepository gameRepository)
        {
            _gameRepository = gameRepository;

            AddCommand = new RelayCommand(Add);
            EditCommand = new RelayCommand(Edit);
            DeleteCommand = new RelayCommand(Delete);
        }

        public void Load()
        {
            var games = _gameRepository.Get();
            Games = new ObservableCollection<GameItemViewModel>(
                games?.Select(game => new GameItemViewModel
                {
                    Id = game.Id,
                    Title = game.Title,
                    Genre = game.Genre,
                    ReleaseDate = game.ReleaseDate
                }));
        }

        private void Add()
        {
            var newGameViewModel = new NewGameViewModel();
            var newGameView = new NewGameView();
            newGameView.DataContext = newGameViewModel;

            newGameView.ShowDialog();

            if (newGameView.DialogResult.HasValue && newGameView.DialogResult.Value)
            {
                var game = new Game(newGameViewModel.Title, newGameViewModel.Genre, newGameViewModel.ReleaseDate);
                _gameRepository.Add(game);

                Games.Add(new GameItemViewModel { Id = game.Id, Title = game.Title, Genre = game.Genre, ReleaseDate = game.ReleaseDate });
            }
        }

        private void Edit()
        {
            if (SelectedGame == null)
            {
                return;
            }

            var game = _gameRepository.Get(SelectedGame.Id);
            var editGameViewModel = new EditGameViewModel
            {
                Id = game.Id,
                Title = game.Title,
                Genre = game.Genre,
                ReleaseDate = game.ReleaseDate
            };

            var editGameView = new EditGameView();
            editGameView.DataContext = editGameViewModel;

            editGameView.ShowDialog();

            if (editGameView.DialogResult.HasValue && editGameView.DialogResult.Value)
            {
                game.Edit(editGameViewModel.Title, editGameViewModel.Genre, editGameViewModel.ReleaseDate);
                _gameRepository.Update(game);

                SelectedGame.Title = game.Title;
                SelectedGame.Genre = game.Genre;
                SelectedGame.ReleaseDate = game.ReleaseDate;
            }
        }

        private void Delete()
        {
            if (SelectedGame == null)
            {
                return;
            }

            _gameRepository.Delete(SelectedGame.Id);
            Games.Remove(SelectedGame);
        }

        public class GameItemViewModel : ObservableObject
        {
            private string _title;

            private GameGenre _genre;

            private DateTime _releaseDate;

            public int Id { get; set; }

            public string Title
            {
                get { return _title; }
                set
                {
                    _title = value;
                    OnPropertyChanged();
                }
            }

            public GameGenre Genre
            {
                get { return _genre; }
                set
                {
                    _genre = value;
                    OnPropertyChanged();
                }
            }

            public DateTime ReleaseDate
            {
                get { return _releaseDate; }
                set
                {
                    _releaseDate = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
