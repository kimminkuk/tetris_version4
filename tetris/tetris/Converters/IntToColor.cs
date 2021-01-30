using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using tetris.Models;
using System.ComponentModel;

namespace tetris.Converters
{
    public class IntToColor : BindableObject, IValueConverter
    {
        public static readonly BindableProperty ConvParamProperty = BindableProperty.Create(nameof(ConvParam), typeof(int), typeof(IntToColor));
        public int ConvParam
        {
            get { return (int)GetValue(ConvParamProperty); }
            set { SetValue(ConvParamProperty, value); }
        }

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
                case Constants.Block_1:
                    return new SolidColorBrush(Color.Green);
                case Constants.Block_2:
                    return new SolidColorBrush(Color.Blue);
                case Constants.Block_3:
                    return new SolidColorBrush(Color.Red);
                case Constants.Block_4:
                    return new SolidColorBrush(Color.Yellow);
                case Constants.Block_5:
                    return new SolidColorBrush(Color.Magenta);
                case Constants.Block_6:
                    return new SolidColorBrush(Color.Lime);
            }
            return new SolidColorBrush(Color.Black);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
