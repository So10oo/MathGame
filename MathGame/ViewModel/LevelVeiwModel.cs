using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MathGame.ViewModel
{
    public class LevelVeiwModel : BaseViewModel
    {
        public string Name { get; set; } = "";

        public Brush ColorName { get; set; } = Brushes.White;

        public int Number { get; set; }

        private StatusLevel _status = StatusLevel.Unavailable;
        public StatusLevel Status {
            get { return _status; }
            set {
                switch (_status) 
                {
                    case StatusLevel.Passed:
                        break;
                    case StatusLevel.Available:
                    case StatusLevel.Unavailable:
                        _status = value;
                        break;
                    default:
                        break;
                }
                OnPropertyChanged(nameof(Status));
            }
        }

        public UIElement? RiddleVisual { get; set; }

        private string answer = "";
        public string Answer
        {
            get
            {
                return answer;
            }
            set
            {
                answer = value;
                //ColorName = ColorNameLevel(answer);
                OnPropertyChanged(nameof(Answer));
            }
        }


        public LevelVeiwModel()
        {
            Name = NumberLevel.ToString() + " уровень";
            Number = NumberLevel++;
            if(Number==1)
                Status = StatusLevel.Available;

        }

        public override string ToString()
        {
            return Name;
        }

        #region static поля и функции
        private static Brush ColorNameLevel(string name)
        {
            var colorHex = int.Parse(name).ToString("X");
            string color = "";
            while (color.Length < 8)
                color += colorHex;
            color = color[0..8];
            return (Brush)new BrushConverter().ConvertFrom("#" + color);
        }

        public static int NumberLevel = 1;

        public enum StatusLevel 
        {
            Passed,
            Available,
            Unavailable
        }
        #endregion


    }
}
