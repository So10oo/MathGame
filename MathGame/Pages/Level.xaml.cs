using MathGame.ViewModel;
using System.Windows.Controls;

namespace MathGame.Pages
{
    /// <summary>
    /// Логика взаимодействия для Level.xaml
    /// </summary>
    public partial class Level : Page
    {
        public Level(MainWindowViewModel p)
        {
            InitializeComponent();
            DataContext = p;
        }
    }
}
