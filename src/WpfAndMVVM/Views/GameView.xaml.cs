using Microsoft.Extensions.DependencyInjection;
using System.Windows.Controls;
using WpfAndMVVM.ViewModels;

namespace WpfAndMVVM.Views
{
    /// <summary>
    /// Interaction logic for GameView.xaml
    /// </summary>
    public partial class GameView : UserControl
    {
        public GameView()
        {
            var gameViewModel = App.AppHost.Services.GetRequiredService<GameViewModel>();
            gameViewModel.Load();

            DataContext = gameViewModel;
            InitializeComponent();
        }
    }
}
