using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using tetris_version4.Models;

namespace tetris_version4.Converters
{
    public class IntToColor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int type = (int)value;
            switch (type)
            {
                case Constants.Block_background:
                    if (parameter != null) return new SolidColorBrush(Color.Transparent);
                    return new SolidColorBrush(Color.Black);

                case Constants.Block_wall:
                    return new SolidColorBrush(Color.Ivory);
                case (int)Constants.BLOCK.Block_1:
                    return new SolidColorBrush(Color.Yellow);
                case (int)Constants.BLOCK.Block_2:
                    return new SolidColorBrush(Color.Red);
                case (int)Constants.BLOCK.Block_3:
                    return new SolidColorBrush(Color.Black);
                case (int)Constants.BLOCK.Block_4:
                    return new SolidColorBrush(Color.Aqua);
                case (int)Constants.BLOCK.Block_5:
                    return new SolidColorBrush(Color.Green);
                case (int)Constants.BLOCK.Block_6:
                    return new SolidColorBrush(Color.Lime);
            }
            return new SolidColorBrush(Color.Black);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
