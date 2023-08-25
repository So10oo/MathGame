using MathGame.ViewModel;
using System;
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

            Random random = new Random();

            for (var i = 0; i < 10; i++) 
            {
                int a = getRandom(random);
                int b = getRandom(random);
                int c = a + b;
                levels.Add(new LevelVeiwModel()
                {
                    //Riddle = a.ToString() + b.ToString() + "=?",
                    Answer = c.ToString(),
                    RiddleVisual = new TextBlock()
                    {
                        Text = a.ToString() + "+" + b.ToString() + "=?",
                        Foreground = Brushes.White,
                        FontSize = 24,
                    },
                });
            }
            return levels;
        }

        private static int getRandom(Random r)
        {
            return r.Next(0,10);
        }

    }
}
