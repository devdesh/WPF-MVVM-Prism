using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Interfaces
{
    /// <summary>
    /// Interface which is exposed by the DataServices to clients for table related functionalities.
    /// </summary>
    public interface ITableService
    {
        List<ITable> GetTables(string filePath);

        ITable GetTableObject();
    }
}
