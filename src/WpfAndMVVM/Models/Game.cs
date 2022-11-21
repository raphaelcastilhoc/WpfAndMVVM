using System;
using System.Windows.Media;

namespace WpfAndMVVM.Models
{
    public class Game
    {
        private Game() { }

        public Game(int id)
        {
            Id = id;
        }

        public Game(string title,
            GameGenre genre,
            DateTime releaseDate,
            int id  = 0)
        {
            Id = id;
            Title = title;
            Genre = genre;
            ReleaseDate = releaseDate;
        }

        public int Id { get; }

        public string Title { get; private set; }

        public GameGenre Genre { get; private set; }

        public DateTime ReleaseDate { get; private set; }

        public void Edit(string title,
            GameGenre genre,
            DateTime releaseDate)
        {
            Title = title;
            Genre = genre;
            ReleaseDate = releaseDate;
        }
    }

    public enum GameGenre
    {
        RPG = 1,
        Horror = 2,
        Strategy = 3,
        Action = 4,
        Sport = 5
    }
}
