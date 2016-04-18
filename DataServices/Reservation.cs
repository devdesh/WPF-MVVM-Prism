using Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DataServices
{
    /// <summary>
    /// This class maps to the Reservation element in Reservation.xml file.
    /// </summary>
    [XmlType("Reservation")]
    public class Reservation : IReservation
    {
        #region Private member variables

        private DateTime _checkInDate;
        private string _customerName;
        private string _contactNumber;
        private int _occupants;
        private List<Table> _table;
        private Guid _reservationGUID;

        #endregion

        #region Constructors

        public Reservation()
        {
            Table = new List<Table>();
        }

        #endregion

        #region Properties
        /// <summary>
        /// GUID 
        /// </summary>
        [XmlElement("ReservationGUID")]
        public Guid ReservationGUID
        {
            get { return _reservationGUID; }
            set { _reservationGUID = value; }
        }

        /// <summary>
        /// Check-in datetime
        /// </summary>
        [XmlElement("CheckInDate")]
        public DateTime CheckInDate
        {
            get { return _checkInDate; }
            set { _checkInDate = value; }
        }

        /// <summary>
        /// Customer name
        /// </summary>
        [XmlElement("CustomerName")]
        public string CustomerName
        {
            get { return _customerName; }
            set { _customerName = value; }
        }

        /// <summary>
        /// Customer contact number
        /// </summary>
        [XmlElement("ContactNumber")]
        public string ContactNumber
        {
            get { return _contactNumber; }
            set { _contactNumber = value; }
        }

        /// <summary>
        /// Booked tables
        /// </summary>
        [XmlElement("Table")]
        public List<Table> Table
        {
            get { return _table; }
            set { _table = value; }
        }

        /// <summary>
        /// No. of Occupants per table
        /// </summary>
        [XmlElement("Occupants")]
        public int Occupants
        {
            get { return _occupants; }
            set { _occupants = value; }
        }
        /// <summary>
        /// Table property exposed to clients
        /// </summary>
        List<ITable> IReservation.Table
        {
            get
            {
                return new List<ITable>(_table);
            }
        }
        #endregion

    }
}
