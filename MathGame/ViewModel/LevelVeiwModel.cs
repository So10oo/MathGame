using System.Windows;

namespace MathGame.ViewModel
{
    public class LevelVeiwModel : BaseViewModel
    {
        public string Name { get; set; } = "";
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

        public LevelVeiwModel()
        {
            Name = NumberLevel.ToString() + " уровень";
            Number = NumberLevel++;
            if(Number==1)
                Status = StatusLevel.Available;

        }

        //public string Riddle { get; set; } = "";

        public UIElement? RiddleVisual { get; set; }

        public string Answer { get; set; } = "";

        public override string ToString()
        {
            return Name;
        }

        static int NumberLevel = 1;

        public enum StatusLevel 
        {
            Passed,
            Available,
            Unavailable
        }
    }
}
