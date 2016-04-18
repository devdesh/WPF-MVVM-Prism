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
    /// This class maps to the Table element in the Tables.xml file.
    /// </summary>
    [XmlType("Table")]
    public class Table : ITable
    {

        #region Private Variables

        private int _id;
        private int _maxOccupancy;

        #endregion

        #region Properties

        /// <summary>
        /// Max occupancy allowed for this table
        /// </summary>
        [XmlAttribute]
        public int MaxOccupancy
        {
            get { return _maxOccupancy; }
            set { _maxOccupancy = value; }
        }

        /// <summary>
        /// Table ID
        /// </summary>
        [XmlAttribute]
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        #endregion
    }
}
