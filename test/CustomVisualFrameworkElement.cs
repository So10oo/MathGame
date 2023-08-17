using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;
using System.Windows.Media;
using System.Windows;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Media.Media3D;

namespace MathGame.View
{
    public class CustomVisualFrameworkElement : FrameworkElement
    {
        // Коллекция всех визуальных объектов.
        VisualCollection theVisuals;
        public CustomVisualFrameworkElement()
        {
            theVisuals = new VisualCollection(this);
            SetCollectionVisual(150, random);
        }

        private readonly Random random = new Random();

        private Visual GetSymbol(Random random)
        {
            const int TextFontSize = 10;
            var text = new FormattedText(random.Next(0, 10).ToString(),
            new System.Globalization.CultureInfo("en-us"),
            FlowDirection.LeftToRight,
            new Typeface("Times New Roman"),
            TextFontSize,
            new SolidColorBrush(Color.FromRgb((byte)random.Next(1, 255), (byte)random.Next(1, 255), (byte)random.Next(1, 233))),
            null,
            VisualTreeHelper.GetDpi(this).PixelsPerDip);

             
            var drawingVisual = new DrawingVisual();
            using (DrawingContext drawingContext = drawingVisual.RenderOpen())
            {
                drawingContext.DrawText(text, new Point(0, 0));
            }

            drawingVisual.Transform = GetAnimation(random,text);

            return drawingVisual;
        }

        private TransformGroup GetAnimation(Random random, FormattedText text)
        {
            int width = 400;
            int height = 200;

            var tg = new TransformGroup();
            var tt = new TranslateTransform();
            var YAnimation = new DoubleAnimation();
            YAnimation.From = 0;
            var Yend = random.Next(0, height);
            YAnimation.To = Yend;
            YAnimation.Duration = TimeSpan.FromSeconds(random.Next(3, 15));
            YAnimation.Completed += (sender, e) =>
            {
                YAnimation.From = Yend;
                Yend = random.Next(0, height);
                YAnimation.To = Yend;
                tt.BeginAnimation(TranslateTransform.YProperty, YAnimation);
            };
            tt.BeginAnimation(TranslateTransform.YProperty, YAnimation);

            var XAnimation = new DoubleAnimation();
            XAnimation.From = 0;
            var Xend = random.Next(0, width);
            XAnimation.To = Xend;
            XAnimation.Duration = TimeSpan.FromSeconds(random.Next(3, 15));
            XAnimation.Completed += (sender, e) =>
            {
                XAnimation.From = Xend;
                Xend = random.Next(0, width);
                XAnimation.To = Xend;
                tt.BeginAnimation(TranslateTransform.XProperty, XAnimation);
            };
            tt.BeginAnimation(TranslateTransform.XProperty, XAnimation);

            var rt = new RotateTransform();
            rt.CenterX = text.Width / 2.0;
            rt.CenterY = text.Height / 2.0;
            var angleAnimation = new DoubleAnimation();
            angleAnimation.From = 0;
            var angleend = random.Next(0, 1660);
            angleAnimation.To = angleend;
            angleAnimation.Duration = TimeSpan.FromSeconds(random.Next(1, 15));
            angleAnimation.Completed += (sender, e) =>
            {
                angleAnimation.From = angleend;
                angleend = random.Next(0, 1660);
                angleAnimation.To = angleend;
                rt.BeginAnimation(RotateTransform.AngleProperty, angleAnimation);
            };
            rt.BeginAnimation(RotateTransform.AngleProperty, angleAnimation);

            tg.Children.Add(rt);
            tg.Children.Add(tt);
            return tg;
        }

        private void SetCollectionVisual(int countSymbol, Random random)
        {
            for (int i = 0; i < countSymbol; i++)
            {
                theVisuals.Add(GetSymbol(random));
            }
        }

        protected override int VisualChildrenCount => theVisuals.Count;
        protected override Visual GetVisualChild(int index)
        {
            // Значение должно быть больше нуля, поэтому разумно это проверить,
            if (index < 0 || index >= theVisuals.Count)
            {
                throw new ArgumentOutOfRangeException();
            }
            return theVisuals[index];
        }
    }
}
