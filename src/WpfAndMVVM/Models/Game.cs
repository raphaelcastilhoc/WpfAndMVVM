using System;

namespace WpfAndMVVM.Models
{
    public class Game
    {
        private Game() { }

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

        public string Title { get; }

        public GameGenre Genre { get; }

        public DateTime ReleaseDate { get; }
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
