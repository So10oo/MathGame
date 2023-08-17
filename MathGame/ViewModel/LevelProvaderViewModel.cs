using MathGame.Commands;
using MathGame.Pages;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace MathGame.ViewModel
{
    public class LevelProvaderViewModel : BaseViewModel
    {

        public ObservableCollection<LevelVeiwModel> Levels { get; set; }

        public LevelVeiwModel SelectLevel { get; set; }

        public LevelProvaderViewModel(MainWindowViewModel d) 
        {
            for (int i = 0; i < 50; i++)
            {
                d.Levels.Add(new LevelVeiwModel()
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
            this.Levels = d.Levels;
            this.d = d;
            SelectLevel = Levels.First();
        }

        public string InAnswer { get; set; } = "";

        public ICommand cmdNextLevel
        {
            get
            {
                return new RelayCommand(() =>
                {
                    if (InAnswer == SelectLevel.Answer)
                    {
                        SelectLevel.IsPassed = true;
                        int l = Levels.IndexOf(SelectLevel);
                        SelectLevel = Levels[l + 1];
                        InAnswer = "";
                    }

                });
            }
        }

        MainWindowViewModel d;

        public ICommand cmdGoLevel
        {
            get
            {
                return new RelayCommand<LevelVeiwModel>((level) =>
                {
                    if (level.IsPassed)
                    {
                        d.CurrentPage = d.LevelPlay;
                        SelectLevel = level;
                    }
                });
            }
        }

    }
}
