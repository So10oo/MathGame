using Microsoft.EntityFrameworkCore;
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
            //using (ApplicationContext db = new ApplicationContext())
            //{
            //    // создаем два объекта User
            //    User tom = new User { Name = "Tom", Age = 33 };
            //    User alice = new User { Name = "Alice", Age = 26 };
            //    User dima = new User { Name = "dima", Age = 23 };


            //    // добавляем их в бд
            //    db.Users.Add(tom);
            //    db.Users.Add(alice);
            //    db.Users.Add(dima);
            //    db.SaveChanges();
            //    txt.Text = "";
            //    txt.Text = "Объекты успешно сохранены\n";

            //    // получаем объекты из бд и выводим на консоль
            //    var users = db.Users.ToList();
            //    txt.Text += "Список объектов:\n";
            //    foreach (User u in users)
            //    {
            //        txt.Text += $"{u.Id}.{u.Name} - {u.Age}\n";
            //    }
            //}

            //object a = new Canvas() {  };
            //var _byte = ObjectToByteArray(a);
            //var _obgect = ByteArrayToObject(_byte);
            //var type = _obgect.GetType();

            var context = new ParserContext();
            context.XmlnsDictionary.Add("","http://schemas.microsoft.com/winfx/2006/xaml/presentation");
            context.XmlnsDictionary.Add("x","http://schemas.microsoft.com/winfx/2006/xaml");
            UIElement cXamlElements = (UIElement)XamlReader.Parse("<TextBlock Text=\"132312\"/>",context);
            label.Content = cXamlElements;

        }

        public static byte[] ObjectToByteArray(object obj)
        {
            var bf = new XmlSerializer(obj.GetType());
            using (var ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }

        public static object ByteArrayToObject(byte[] arrBytes)
        {
            using (var memStream = new MemoryStream())
            {
                var binForm = new XmlSerializer(arrBytes.GetType());
                memStream.Write(arrBytes, 0, arrBytes.Length);
                memStream.Seek(0, SeekOrigin.Begin);
                var obj = binForm.Deserialize(memStream);
                return obj;
            }
        }
    }

    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public byte[]? R { get; set; }
    }
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public ApplicationContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=helloappdb;Trusted_Connection=True;");
        }
    }
}
