using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Interfaces
{
    /// <summary>
    /// Table object exposed by ITable by the DataServices module to clients.
    /// </summary>
    public interface ITable
    {

        int MaxOccupancy
        {
            get;
            set;
        }


        int Id
        {
            get;
            set;
        }

        
    }
}
