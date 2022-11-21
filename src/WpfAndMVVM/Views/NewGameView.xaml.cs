using System;
using System.Linq;
using System.Windows;
using WpfAndMVVM.Models;

namespace WpfAndMVVM.Views
{
    /// <summary>
    /// Interaction logic for NewGameView.xaml
    /// </summary>
    public partial class NewGameView : Window
    {
        public NewGameView()
        {
            InitializeComponent();
            ComboBoxGenre.ItemsSource = Enum.GetValues(typeof(GameGenre)).Cast<GameGenre>();
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
