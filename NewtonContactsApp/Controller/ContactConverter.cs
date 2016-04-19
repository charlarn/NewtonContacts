using NewtonContactsApp.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace NewtonContactsApp.Controller
{
    class ContactConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return value as Contact;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value as Contact;
        }
    }
}
