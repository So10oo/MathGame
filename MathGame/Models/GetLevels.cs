using MathGame.ViewModel;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Media;

namespace MathGame.Models
{
    public static class Levels
    {
        public static ObservableCollection<LevelVeiwModel> GetLevels()
        {
            var levels = new ObservableCollection<LevelVeiwModel>();

            for (var i = 0; i < 10; i++) 
            {
                levels.Add(new LevelVeiwModel()
                {
                    Riddle = i.ToString() + "=?",
                    Answer = i.ToString(),
                    RiddleVisual = new TextBlock()
                    {
                        Text = i.ToString(),
                        Foreground = Brushes.Gray,
                    },
                });
            }
            return levels;
        }

    }
}
