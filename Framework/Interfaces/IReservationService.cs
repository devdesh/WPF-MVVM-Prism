using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Interfaces
{
    /// <summary>
    /// Interface which is exposed by the DataServices to clients for Reservation related functionalities.
    /// </summary>
    public interface IReservationService
    {
        void AddReservation(IReservation reservation);

        void RemoveReservation(IReservation reservation);

        void EditReservation(IReservation reservation);

        bool SaveReservation(string filePath);

        IReservation GetReservationObject();

        void SetTableObjectOnReservation(ITable table,IReservation reservation);

        void ClearTablesOnReservation(IReservation reservation);

        List<IReservation> GetReservations(string filepath);
    }
}
