using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Windows;
using System.Windows.Markup;
using System.Xml.Serialization;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                // создаем 
                Level l1 = new Level { Name = "1", XamlRiddle = "<TextBlock Text=\"1,2,4,5,6,7,?\" VerticalAlignment=\"Center\" HorizontalAlignment=\"Center\"/>", Answer = "10" };
                Level l2 = new Level { Name = "2", XamlRiddle = "<TextBlock Text=\"1,2,4,8,?\" VerticalAlignment=\"Center\" HorizontalAlignment=\"Center\"/>", Answer = "16" };
                Level l3 = new Level { Name = "3", XamlRiddle = "<TextBlock Text=\"1,3,5,?\" VerticalAlignment=\"Center\" HorizontalAlignment=\"Center\"/>", Answer = "7" };
                Level l5 = new Level { Name = "4", XamlRiddle = "<TextBlock Text=\"3,1,4,?\" VerticalAlignment=\"Center\" HorizontalAlignment=\"Center\"/>", Answer = "1" };
                Level l6 = new Level { Name = "5", XamlRiddle = "<TextBlock Text=\"0,1,1,2,3,5,?\" VerticalAlignment=\"Center\" HorizontalAlignment=\"Center\"/>", Answer = "8" };
                Level l7 = new Level { Name = "6", XamlRiddle = "<TextBlock Text=\"1,2,4,7,?\" VerticalAlignment=\"Center\" HorizontalAlignment=\"Center\"/>", Answer = "11" };

                // добавляем их в бд
                db.Levels.Add(l1);
                db.Levels.Add(l2);
                db.Levels.Add(l3);
                db.Levels.Add(l5);
                db.Levels.Add(l6);
                db.Levels.Add(l7);

                db.SaveChanges();
                txt.Text = "";
                txt.Text = "Объекты успешно сохранены\n";

            }
 

        }
    }

    public class Level
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string? Name { get; set; }

        public int Number { get; set; }

        public string? XamlRiddle { get; set; }

        [StringLength(50)]
        public string? Answer { get; set; }

    }

    public class ApplicationContext : DbContext
    {
        public DbSet<Level> Levels => Set<Level>();
        public ApplicationContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-N76QD8J\SQLEXPRESS;Database=MathGameLevels;Trusted_Connection=True;Encrypt=False;");
        }
    }
}
