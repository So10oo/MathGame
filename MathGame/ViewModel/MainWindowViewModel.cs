using MathGame.Commands;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Input;

namespace MathGame.ViewModel
{
    public class MainWindowViewModel : BaseViewModel
    {
        private readonly Page Main;
        private readonly Page LevelSelection;
        public readonly Page LevelPlay;
        public Page CurrentPage { get; set; }

        public LevelProvaderViewModel LevelProvader { get; set; }

        public ObservableCollection<LevelVeiwModel> Levels { get; set; } = new ObservableCollection<LevelVeiwModel>();

        public MainWindowViewModel()
        {
            Main = new Pages.Main(this);
            LevelSelection = new Pages.LevelSelection(this);
            LevelPlay = new Pages.Level(this);

            LevelProvader = new LevelProvaderViewModel(this);

            CurrentPage = Main;
        }


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
 
                return new RelayCommand(() => CurrentPage = LevelPlay);
            }
        }

    }
}
