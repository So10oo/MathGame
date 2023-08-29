using MathGame.ViewModel;

namespace MathGame.Pages
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class MainPage 
    {
        public MainPage(MainWindowViewModel p) 
        {
            InitializeComponent();
            DataContext = p;
        }
    }
}
