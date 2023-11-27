using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Converters
{
    public class TopThreeColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => (int)value switch
        {
            1 => Colors.Gold,
            2 => Colors.Silver,
            3 => Colors.Brown,
            _ => Colors.White
        };




        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
