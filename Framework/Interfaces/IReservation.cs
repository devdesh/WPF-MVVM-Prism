using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Interfaces
{
    /// <summary>
    /// Reservation object exposed by IReservation by the DataServices module to clients.
    /// </summary>
    public interface IReservation
    {
        Guid ReservationGUID { get; set; }
        DateTime CheckInDate{get; set;}
        string CustomerName { get; set; }
        string ContactNumber { get; set; }
        int Occupants { get; set; }
        List<ITable> Table { get;}
    }
}
