using System;
using System.Diagnostics;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using static MathGame.ViewModel.LevelVeiwModel;

namespace MathGame.Converter
{
    public class boolToFillConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var status = (StatusLevel)value;
            switch (status)
            {
                case StatusLevel.Passed:
                    return Brushes.Green;
                case StatusLevel.Available:
                    return Brushes.Orange;
                case StatusLevel.Unavailable:
                    return Brushes.Red;
                default:
                    return Brushes.Firebrick;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}
