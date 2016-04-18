using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Interfaces;

namespace DataServices
{
    /// <summary>
    /// This class provided functionalities for fetching table information.
    /// </summary>
    public class TableService : ITableService
    {
        #region Public Methods
        /// <summary>
        /// Gets Tables list from Tables.xml file
        /// </summary>
        /// <param name="filePath">file path</param>
        /// <returns>list of tables</returns>
        public List<ITable> GetTables(string filePath)
        {
            List<ITable> tables = new List<ITable>();
            try
            {
                TableRoot tablesRootList = XMLHelper.DeSerialize<TableRoot>(filePath);

                foreach (var table in tablesRootList.Tables)
                {
                    tables.Add(table as ITable);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
           return tables;
        }

        /// <summary>
        /// Creates a new table object
        /// </summary>
        /// <returns>ITtable object</returns>
        public ITable GetTableObject()
        {
            return new Table();
        }

        #endregion
    }
}
