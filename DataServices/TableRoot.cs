using DataServices;
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
    /// This class maps to the Table root in the Tabes.xml file.
    /// </summary>
    [Serializable, XmlRoot("Tables"), XmlType("Tables")]
    public class TableRoot
    {
        #region Private Variables

        private List<Table> _tablesList;

        #endregion

        #region Properties

        /// <summary>
        /// Tables element collection
        /// </summary>
        [XmlElement("Table")]
        public List<Table> Tables
        {
            get { return _tablesList; }
            set { _tablesList = value; }
        }

        #endregion

        #region Conctructor

        public TableRoot()
        {
            this.Tables = new List<Table>();
        }
        #endregion
    }
}
