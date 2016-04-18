using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    /// <summary>
    /// Helper class for mapping XML File path settings.
    /// </summary>
    public static class SettingsHelper
    {
        #region Private Variables
        private static string _reservationsXMLFilePath;
        private static string _tablesXMLFilePath;
        #endregion

        #region Public Properties
        /// <summary>
        /// Reservations XML File Path
        /// </summary>
        public static string ReservationsXMLFilePath
        {
            get { return _reservationsXMLFilePath; }
            set { _reservationsXMLFilePath = value; }
        }

        /// <summary>
        /// Tables XML File Path
        /// </summary>
        public static string TablesXMLFilePath
        {
            get { return _tablesXMLFilePath; }
            set { _tablesXMLFilePath = value; }
        }

        #endregion
    }
}
