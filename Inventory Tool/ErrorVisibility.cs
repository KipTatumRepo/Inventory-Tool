using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Inventory_Tool
{
    /// <summary>
    /// This converter will hide the warning textblock if there is no error
    /// </summary>
	public class ErrorVisibility : IValueConverter
	{
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var collection = value as ReadOnlyCollection<ValidationError>;
            if (collection != null && collection.Count > 0)
            {
                return Visibility.Visible;
            }
            else
            {
                return Visibility.Collapsed;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return new object();
        }
    }
}
