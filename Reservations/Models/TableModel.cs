using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservations.Models
{
    /// <summary>
    /// Table Model class.
    /// </summary>
    public class TableModel : INotifyPropertyChanged
    {
        #region Private Vraiables
        private bool _isTableSelected;
        private int _tableOccupancy;
        private int _tableID;

        #endregion

        #region Properties

        public int TableID
        {
            get { return _tableID; }
            set 
            { 
                _tableID = value;
                this.OnPropertyChanged("TableID");
            }
        }

        public bool IsTableSelected
        {
            get { return _isTableSelected; }
            set 
            {
                _isTableSelected = value;
                this.OnPropertyChanged("IsTableSelected");
            }
        }
        

        public int TableOccupancy
        {
            get { return _tableOccupancy; }
            set 
            {
                _tableOccupancy = value;
                this.OnPropertyChanged("TableOccupancy");
            }
        }

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (null != PropertyChanged)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}
