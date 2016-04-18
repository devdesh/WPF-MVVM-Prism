using Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservations.Models
{
    /// <summary>
    /// Reservation Model class
    /// </summary>
    public class ReservationModel : INotifyPropertyChanged
    {
        #region Private member variables

        private DateTime _checkInDate;
        private string _customerName;
        private string _contactNumber;
        private int _partyOf;
        private ObservableCollection<TableModel> _table;
        private IReservation _reservationObj;

        

        #endregion

        #region Constructor

        public ReservationModel()
        {
            _table = new ObservableCollection<TableModel>();
        }

        #endregion

        #region Properties

        
        public DateTime CheckInDate
        {
            get { return _checkInDate; }
            set
            { 
                _checkInDate = value;
                this.OnPropertyChanged("CheckInDate");
            }
        }


        public string CustomerName
        {
            get { return _customerName; }
            set
            { 
                _customerName = value;
                this.OnPropertyChanged("CustomerName");
            }
        }

        public string ContactNumber
        {
            get { return _contactNumber; }
            set 
            {
                _contactNumber = value;
                this.OnPropertyChanged("ContactNumber");
            }
        }

        public ObservableCollection<TableModel> Table
        {
            get { return _table; }
            set
            {
                _table = value;
            }
        }

        public int PartyOf
        {
            get { return _partyOf; }
            set 
            { 
                _partyOf = value;
                this.OnPropertyChanged("PartyOf");
            }
        }

        public IReservation ReservationObj
        {
            get { return _reservationObj; }
            set { _reservationObj = value; }
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
