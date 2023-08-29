using MathGame.ViewModel;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Markup;

namespace MathGame.Models
{
    public static class Levels
    {
        public static ObservableCollection<LevelVeiwModel> GetLevels()
        {
            var levels = new ObservableCollection<LevelVeiwModel>();
            using (LevelsDAL.EF.LevelsDAL context = new LevelsDAL.EF.LevelsDAL())
            {
                var parserContext = new ParserContext();
                parserContext.XmlnsDictionary.Add("", "http://schemas.microsoft.com/winfx/2006/xaml/presentation");
                parserContext.XmlnsDictionary.Add("x", "http://schemas.microsoft.com/winfx/2006/xaml");
                foreach (var level in context.Levels)
                {
                    levels.Add(new LevelVeiwModel()
                    {
                        Answer = level.Answer,
                        RiddleVisual = (UIElement)XamlReader.Parse(level.XamlRiddle, parserContext),
                    });
                }
            }
            return levels;
        }


    }
}
