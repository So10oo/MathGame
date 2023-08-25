using MathGame.Commands;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;

namespace MathGame.ViewModel
{
    public class MainWindowViewModel : BaseViewModel
    {

        public Page CurrentPage { get; set; }
        public LevelVeiwModel? SelectLevel { get; set; }
        public LevelVeiwModel CurrentLevel { get; set; }
        public string InAnswer { get; set; } = "";
        public ObservableCollection<LevelVeiwModel> Levels { get; set; } = new ObservableCollection<LevelVeiwModel>();

        private readonly Page Main;
        private readonly Page LevelSelection;
        private readonly Page LevelPlay;

        private int _maxLevelPassed;
        private int MaxLevelPassed {
            get { return _maxLevelPassed; }
            set { if(_maxLevelPassed < value) _maxLevelPassed = value;} 
        }

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
        public ICommand GoLevelSelection
        {
            get
            {
                return new RelayCommand(() => CurrentPage = LevelSelection);
            }
        }

        public ICommand GoMainMenu
        {
            get
            {
                return new RelayCommand(() => CurrentPage = Main);
            }
        }

        public ICommand GoNewPlay
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


        public ICommand EnteringResponse
        {
            get
            {
                return new RelayCommand(() =>
                {
                    if (InAnswer.Replace(" ", "") == CurrentLevel.Answer)
                    {
                        CurrentLevel.Status = LevelVeiwModel.StatusLevel.Passed;
                        int _level = Levels.IndexOf(CurrentLevel);
                        CurrentLevel = Levels[++_level];
                        CurrentLevel.Status = LevelVeiwModel.StatusLevel.Available;
                        InAnswer = "";
                        MaxLevelPassed = _level;
                    }

                });
            }
        }

        public ICommand StartSelectedLevel
        {
            get
            {
                return new RelayCommand<LevelVeiwModel>((level) =>
                {
                    if ((int)level.Status<(int)LevelVeiwModel.StatusLevel.Unavailable)
                    {
                        CurrentPage = LevelPlay;
                        CurrentLevel = level;
                    }
                });
            }
        }

        public ICommand ContinueGame
        {
            get
            {
                return new RelayCommand(() =>
                {
                    CurrentPage = LevelPlay;
                    CurrentLevel = Levels[MaxLevelPassed];
                });
            }
        }
        #endregion
    }
}
