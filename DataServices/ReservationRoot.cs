using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DataServices
{
    [Serializable, XmlRoot("Reservations"), XmlType("Reservations")]
    public class ReservationRoot
    {
        #region Private Variables

        private List<Reservation> _reservations = null;

        #endregion

        #region Constructor

        public ReservationRoot()
        {
            _reservations = new List<Reservation>();
        }
        #endregion

        #region Properties

        /// <summary>
        /// XML Root Element for Reservations.xml file.
        /// </summary>
        [XmlElement("Reservation")]
        public List<Reservation> Reservations
        {
            get { return _reservations; }
            set { _reservations = value; }
        }

        #endregion
    }
}
