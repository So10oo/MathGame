using System.Windows;
using System.Windows.Controls;

namespace MathGame.ViewModel
{
    public class LevelVeiwModel : BaseViewModel
    {
        public string Name { get; set; } = "";

        public int Number { get; set; }

        static int NumberLevel = 1;

        public bool IsPassed { get; set; } = false;

        public LevelVeiwModel()
        {
            Name = NumberLevel.ToString() + " уровень";
            Number = NumberLevel++;
            if(Number==1)
                IsPassed = true;

        }

        public string Riddle { get; set; } = "";

        public UIElement RiddleVisual { get; set; }

        public string Answer { get; set; } = "";

        public override string ToString()
        {
            return Name;
        }
    }
}
