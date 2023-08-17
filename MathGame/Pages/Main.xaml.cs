using MathGame.ViewModel;

namespace MathGame.Pages
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main 
    {
        public Main(MainWindowViewModel p) 
        {
            InitializeComponent();
            DataContext = p;
        }
    }
}
