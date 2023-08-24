using MathGame.Commands;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;

namespace MathGame.ViewModel
{
    public class MainWindowViewModel : BaseViewModel
    {

        public Page CurrentPage { get; set; }
        public LevelVeiwModel SelectLevel { get; set; }
        public LevelVeiwModel CurrentLevel { get; set; }
        public string InAnswer { get; set; } = "";
        public ObservableCollection<LevelVeiwModel> Levels { get; set; } = new ObservableCollection<LevelVeiwModel>();

        private readonly Page Main;
        private readonly Page LevelSelection;
        private readonly Page LevelPlay;
        private int MaxLevelProd { get; set; }

        public MainWindowViewModel()
        {
            Main = new Pages.Main(this);
            LevelSelection = new Pages.LevelSelection(this);
            LevelPlay = new Pages.Level(this);
            CurrentPage = Main;
            Levels = MathGame.Models.Levels.GetLevels();
            CurrentLevel = Levels.First();

        }

        #region Command
        public ICommand cmdLevelSelection
        {
            get
            {
                return new RelayCommand(() => CurrentPage = LevelSelection);
            }
        }

        public ICommand cmdMainMenu
        {
            get
            {
                return new RelayCommand(() => CurrentPage = Main);
            }
        }

        public ICommand cmdGoPlay
        {
            get
            {
                return new RelayCommand(() =>
                {
                    CurrentPage = LevelPlay;
                    CurrentLevel = Levels.First();
                });
            }
        }


        public ICommand cmdNextLevel
        {
            get
            {
                return new RelayCommand(() =>
                {
                    if (InAnswer == CurrentLevel.Answer)
                    {
                        CurrentLevel.IsPassed = true;
                        int l = Levels.IndexOf(CurrentLevel);
                        CurrentLevel = Levels[l + 1];
                        InAnswer = "";
                        MaxLevelProd++;
                    }

                });
            }
        }
        public ICommand cmdGoLevel
        {
            get
            {
                return new RelayCommand<LevelVeiwModel>((level) =>
                {
                    if (level.IsPassed)
                    {
                        CurrentPage = LevelPlay;
                        CurrentLevel = level;
                    }
                });
            }
        }

        public ICommand cmdGoEndLevel
        {
            get
            {
                return new RelayCommand(() =>
                {
                    CurrentPage = LevelPlay;
                    CurrentLevel = Levels[MaxLevelProd];
                });
            }
        }
        #endregion
    }
}
