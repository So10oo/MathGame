using MathGame.ViewModel;

namespace MathGame.Pages
{
    /// <summary>
    /// Логика взаимодействия для LevelSelection.xaml
    /// </summary>
    public partial class LevelSelection 
    {
        public LevelSelection(MainWindowViewModel p)
        {
            InitializeComponent();
            DataContext = p;
        }
    }
}
