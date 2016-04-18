using Framework;
using Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServices
{
    /// <summary>
    /// This class exposes functionalities needed for adding,editing,deleting reservation.
    /// </summary>
    public class ReservationService : IReservationService
    {
        #region Private Variables

        private ReservationRoot _reservationsRoot;

        #endregion

        #region Constructor

        public ReservationService()
        {
            _reservationsRoot = new ReservationRoot();
        }

        #endregion

        #region Public Methods
        /// <summary>
        /// Adds new reservation object to the root list
        /// </summary>
        /// <param name="reservation">IReservation object</param>
        public void AddReservation(IReservation reservation)
        {
            _reservationsRoot.Reservations.Add(reservation as Reservation);
        }

        /// <summary>
        /// Removes reservation object from the root list
        /// </summary>
        /// <param name="reservation">IReservation object</param>
        public void RemoveReservation(IReservation reservation)
        {
            Reservation reservationTobeRemoved = _reservationsRoot.Reservations.Where(r => r.ReservationGUID == reservation.ReservationGUID).FirstOrDefault();
            _reservationsRoot.Reservations.Remove(reservationTobeRemoved);
        }

        /// <summary>
        /// Saves reservation XML file.
        /// </summary>
        /// <param name="filePath">file path</param>
        /// <returns>bool flag </returns>
        public bool SaveReservation(string filePath)
        {
            bool reservationSaved = false;
            try
            {
                reservationSaved = XMLHelper.Serialize<ReservationRoot>(filePath, _reservationsRoot);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return reservationSaved;
        }

        /// <summary>
        /// Gets IReservation object 
        /// </summary>
        /// <returns></returns>
        public IReservation GetReservationObject()
        {
            return new Reservation { ReservationGUID = Guid.NewGuid()};
        }

        /// <summary>
        /// Sets Table obj on Reservation obj
        /// </summary>
        /// <param name="table"></param>
        /// <param name="reservation"></param>
        public void SetTableObjectOnReservation(ITable table, IReservation reservation)
        {
            if (table != null && reservation != null)
            {
                (reservation as Reservation).Table.Add(table as Table);
            }
        }

        /// <summary>
        /// Clears table collection
        /// </summary>
        /// <param name="reservation"></param>
        public void ClearTablesOnReservation(IReservation reservation)
        {
            if (reservation != null && reservation.Table != null && reservation.Table.Count > 0)
            {
                (reservation as Reservation).Table.Clear();
            }
        }

        /// <summary>
        /// Gets today's and future reservations
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public List<IReservation> GetReservations(string filepath)
        {
            List<IReservation> reservations;
            try
            {
                _reservationsRoot = XMLHelper.DeSerialize<ReservationRoot>(filepath);
                reservations = new List<IReservation>();
                if (_reservationsRoot != null)
                {
                    foreach (var reservation in _reservationsRoot.Reservations)
                    {
                        if (reservation.CheckInDate >= DateTime.Today.Date)
                        {
                            reservations.Add(reservation as IReservation);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return reservations;

        }

        /// <summary>
        /// Edits reservation
        /// </summary>
        /// <param name="reservation"></param>
        public void EditReservation(IReservation reservation)
        {
            Reservation reservationTobeEdited = _reservationsRoot.Reservations.Where(r => r.ReservationGUID == reservation.ReservationGUID).FirstOrDefault();
            if (reservationTobeEdited != null)
            {
                reservationTobeEdited.ContactNumber = reservation.ContactNumber;
                reservationTobeEdited.CheckInDate = reservation.CheckInDate;
                reservationTobeEdited.CustomerName = reservation.CustomerName;
                reservationTobeEdited.Occupants = reservation.Occupants;
                reservationTobeEdited.Table = (reservation as Reservation).Table;
            }
        }

        #endregion

    }
}
