using System;
using WpfAndMVVM.Models;

namespace WpfAndMVVM.ViewModels
{
    public class NewGameViewModel
    {
        public string Title { get; set; }

        public GameGenre Genre { get; set; }

        public DateTime ReleaseDate { get; set; }
    }
}
