using Reservations.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Reservations.Converters
{
    /// <summary>
    /// Converter to display tables selected in string format
    /// </summary>
    public class DisplayTablesSelectedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string tablesSelected = string.Empty;
            if (value != null)
            {
                int count = 0;
                ObservableCollection<TableModel> tables = value as ObservableCollection<TableModel>;
                foreach (TableModel tb in tables)
                {
                    count++;
                    tablesSelected = tablesSelected + tb.TableID.ToString();
                    if (count < tables.Count)
                    {
                        tablesSelected = tablesSelected + ",";
                    }
                }

            }
            return tablesSelected;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
