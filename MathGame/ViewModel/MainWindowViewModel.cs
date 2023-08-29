using MathGame.Commands;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace MathGame.ViewModel
{
    public class MainWindowViewModel : BaseViewModel
    {

        public Page CurrentPage { get; set; }
        public LevelVeiwModel? SelectLevel { get; set; }
        public LevelVeiwModel CurrentLevel { get; set; }
        public string Answer { get; set; } = "";
        public ObservableCollection<LevelVeiwModel> Levels { get; set; } = new ObservableCollection<LevelVeiwModel>();

        private readonly Page Main;
        private readonly Page LevelSelection;
        private readonly Page LevelPlay;

        private int _maxLevelPassed;
        private int MaxLevelPassed
        {
            get { return _maxLevelPassed; }
            set { if (_maxLevelPassed < value) _maxLevelPassed = value; }
        }


        private bool _sound;
        public bool Sound
        {
            get
            {
                return _sound;
            }
            set
            {
                _sound = value;
                if (_sound)
                    player.Play();
                else
                    player.Pause();
                OnPropertyChanged(nameof(Sound));
            }
        }

        private MediaPlayer player = new MediaPlayer();

        public MainWindowViewModel()
        {
            Main = new Pages.MainPage(this);
            LevelSelection = new Pages.LevelSelection(this);
            LevelPlay = new Pages.Level(this);
            CurrentPage = Main;

            Levels = MathGame.Models.Levels.GetLevels();

            CurrentLevel = Levels.First();


            Uri uri = new Uri(@"Sound\Camel-by-Camel.wav", UriKind.Relative);
            player.Open(uri);
            player.Volume = 0.015;
            Sound = true;

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
                    if (Answer.Replace(" ", "") == CurrentLevel.Answer)
                    {
                        CurrentLevel.Status = LevelVeiwModel.StatusLevel.Passed;
                        int _level = Levels.IndexOf(CurrentLevel);
                        Answer = "";
                        if (Levels.Count > _level + 1)
                        {
                            CurrentLevel = Levels[++_level];
                            CurrentLevel.Status = LevelVeiwModel.StatusLevel.Available;
                            MaxLevelPassed = _level;
                        }
                        else
                        {
                            CurrentPage = Main;
                        }
                    }

                });
            }
        }

        public ICommand NextLevel
        {
            get
            {
                return new RelayCommand(() =>
                {
                    int _level = Levels.IndexOf(CurrentLevel);
                    CurrentLevel = Levels[++_level];
                    Answer = "";
                },
                () =>
                {
                    int _level = Levels.IndexOf(CurrentLevel);
                    if (Levels.Count > _level + 1)
                    {
                        if ((int)Levels[_level + 1].Status < (int)LevelVeiwModel.StatusLevel.Unavailable)
                            return true;
                        else
                            return false;
                    }
                    else
                        return false;

                });
            }
        }

        public ICommand PreviousLevel
        {
            get
            {
                return new RelayCommand(() =>
                {
                    int _level = Levels.IndexOf(CurrentLevel);
                    CurrentLevel = Levels[--_level];
                    Answer = "";
                },
                () =>
                {
                    int _level = Levels.IndexOf(CurrentLevel);
                    if (_level > 0)
                        return true;
                    else
                        return false;
                });
            }
        }

        public ICommand StartSelectedLevel
        {
            get
            {
                return new RelayCommand<LevelVeiwModel>((level) =>
                {
                    if ((int)level.Status < (int)LevelVeiwModel.StatusLevel.Unavailable)
                    {
                        CurrentPage = LevelPlay;
                        CurrentLevel = level;
                    }
                });
            }
        }

        //CloseApplication

        public ICommand CloseApplication
        {
            get
            {
                return new RelayCommand<Page>((page) =>
                {
                    var window = Window.GetWindow(page);
                    window?.Close();
                });
            }
        }

        //public ICommand CloseApplication { get; set; }

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
