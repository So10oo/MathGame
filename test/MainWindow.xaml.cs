using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Ellipse e = new Ellipse();
            e.Width = 10;
            e.Height = 10;
            e.Fill = Brushes.Red;
            canvas.Children.Add(e);

            Random random = new Random();    
            var path = new PathGeometry();
            var p = new PathFigure();
            
            p.StartPoint=getPointRandom(random);
            LineSegment a1;
            for (int i = 0; i < 10; i++)
            {
                a1 = new LineSegment();
                a1.Point = getPointRandom(random);
                p.Segments.Add(a1);
            }
            path.Figures.Add(p);

            var d = new DoubleAnimationUsingPath();
            d.PathGeometry = path;
            d.RepeatBehavior = RepeatBehavior.Forever;
            d.Duration = new Duration(new TimeSpan(0, 0, 5));

            d.Source = PathAnimationSource.X;
            e.BeginAnimation(Canvas.LeftProperty, d);

            d.Source = PathAnimationSource.Y;
            e.BeginAnimation(Canvas.TopProperty, d);


        }

        private Point getPointRandom(Random r) 
        {
            return new Point(r.Next(0, 500), r.Next(0, 500));
        }



        private MediaPlayer player = new MediaPlayer();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            player.Open(new Uri(@"Sound\Camel-by-Camel.wav", UriKind.Relative));
            player.Play();
        }
    }
}
