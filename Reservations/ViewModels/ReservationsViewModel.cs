using Framework;
using Framework.Events;
using Framework.Interfaces;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using Reservations.Models;
using Reservations.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace Reservations.ViewModels
{
    public class ReservationsViewModel : ViewModelBase , IDataErrorInfo
    {
        #region Private Variables
        private ITableService _tableService;
        private IReservationService _reservationService;
        private ObservableCollection<TableModel> _tables;
        private string _customerName;
        private string _customerContactNumber;
        private int _partyOf;
        private string _tablesSelected;
        private DateTime _checkinDate;
        private DelegateCommand _saveReservationsCommand;
        private DelegateCommand _cancelCommand;
        private bool _isAddNewReservation;
        private bool _isEditReservation;
        private bool _isDeleteReservation;
        private ReservationModel _selectedReservationModel;
        private ReservationsView _reservationsView;
        private IEventAggregator _eventAggregtor;
        private string _errorMsg;

        #endregion

        #region Properties
        public ReservationsView ReservationsView
        {
            get { return _reservationsView; }
            set { _reservationsView = value; }
        }

        public ReservationModel SelectedReservationModel
        {
            get { return _selectedReservationModel; }
            set { _selectedReservationModel = value; }
        }


        public bool IsDeleteReservation
        {
            get { return _isDeleteReservation; }
            set { _isDeleteReservation = value; }
        }


        public bool IsAddNewReservation
        {
            get { return _isAddNewReservation; }
            set { _isAddNewReservation = value; }
        }

        public bool IsEditReservation
        {
            get { return _isEditReservation; }
            set { _isEditReservation = value; }
        }

        public DelegateCommand SaveReservationsCommand
        {
            get 
            { 
                return _saveReservationsCommand = new DelegateCommand(ExecuteSaveReservationsCommand); 
            }
        }

        
        public DelegateCommand CancelCommand
        {
            get
            {
                return _cancelCommand = new DelegateCommand(ExecuteCancelCommand);
            }
        }

        
        public DateTime CheckinDate
        {
            get 
            { 
                return _checkinDate;
            }
            set 
            { 
                _checkinDate = value;
                OnPropertyChanged("CheckinDate");
            }
        }

        public string TablesSelected
        {
            get { return _tablesSelected; }
            set 
            { 
                _tablesSelected = value;
                OnPropertyChanged("TablesSelected");
            }
        }

        public int PartyOf
        {
            get { return _partyOf; }
            set 
            { 
                _partyOf = value;
                OnPropertyChanged("PartyOf");
            }
        }


        public string CustomerContactNumber
        {
            get { return _customerContactNumber; }
            set 
            { 
                _customerContactNumber = value;
                OnPropertyChanged("CustomerContactNumber");
            }
        }

        public string CustomerName
        {
            get { return _customerName; }
            set 
            { 
                _customerName = value;
                OnPropertyChanged("CustomerName");
            }
        }

        public ObservableCollection<TableModel> Tables
        {
            get { return _tables; }
            set 
            { 
                _tables = value; 
            }
        }

        #endregion

        #region Constructor
        /// <summary>
        /// Creates new ReservationsViewModel object
        /// </summary>
        /// <param name="tableService">ITableService injected through prism</param>
        /// <param name="reservationService">IReservationService injected through prism</param>
        /// <param name="eventAggregator">IEventAggregator injected through prism</param>
        public ReservationsViewModel(ITableService tableService, IReservationService reservationService,IEventAggregator eventAggregator)
        {
            _eventAggregtor = eventAggregator;
            _tables = new ObservableCollection<TableModel>();
            _tableService = tableService;
            _reservationService = reservationService;
            this.CheckinDate = DateTime.Now;
            try
            {
                this.LoadTableInformation();
            }
            catch (Exception ex)
            {
                //log execption
                //TODO: log
            }

        }

        #endregion

        #region Private Methods
        /// <summary>
        /// Loads table information from Tables.XML file
        /// </summary>
        private void LoadTableInformation()
        {
            try
            {
                //get tables list from TableService
                List<ITable> tablesList = _tableService.GetTables(SettingsHelper.TablesXMLFilePath);
                //create a TableModel observable collection to bind to listbox
                foreach (ITable table in tablesList)
                {
                    Tables.Add(new TableModel { TableID = table.Id, IsTableSelected = false, TableOccupancy = table.MaxOccupancy });
                }
            }
            catch (Exception ex)
            {
                throw ex;
                //TODO: log exception
            }
        }

        /// <summary>
        /// Command for Save button
        /// </summary>
        /// <param name="obj">command parameter</param>
        private void ExecuteSaveReservationsCommand(object obj)
        {
            //validations
            if (!this.CheckIfTableIsSelected())
            {
                MessageBox.Show(Resource.NoTableSelectedMsg);
                return;
            }
            if (this.CheckIfSelectedTablesAreBooked())
            {
                MessageBox.Show(Resource.SelectedTableAlreadyBookedMsg);
                return;
            }
            if (!this.CheckIfTablesAndPartyMatch())
            {
                MessageBox.Show(Resource.SelectedTableAndPartyMismatchMsg);
                return;
            }
            if (!this.CheckIfReservationTimeFallsInRange())
            {
                MessageBox.Show(Resource.ReservationTimeErrorMsg);
                return;
            }
            //adding new reservation
            if (this.IsAddNewReservation)
            {
                this.AddReservation();
            }
                //editing reservation
            else if (this.IsEditReservation)
            {
                this.EditReservation(this.SelectedReservationModel);
            }
            this.CloseWindow();
        }

        /// <summary>
        /// Adds and save new reservation
        /// </summary>
        private void AddReservation()
        {
            //add reservation
            this.AddNewReservation();
            //save resrvation through ReservationService
            bool isSaveSuccess = _reservationService.SaveReservation(SettingsHelper.ReservationsXMLFilePath);
            if (isSaveSuccess)
            {
                this.IsAddNewReservation = false;
                this.RefreshReservationData();
            }
        }

        /// <summary>
        /// Adds new reservation
        /// </summary>
        private void AddNewReservation()
        {
            //Create a New Resrvation Model
            ReservationModel reservationModel = this.CreateReservationModel();
            //Create new IReservation object
            IReservation reservation = this.CreateReservation(reservationModel);
            //add new reservation ReservationService
            _reservationService.AddReservation(reservation);
        }

        /// <summary>
        /// Creates a Reservation Model to bind to the UI components
        /// </summary>
        /// <returns></returns>
        private ReservationModel CreateReservationModel()
        {
            ReservationModel reservationModel = new ReservationModel();
            reservationModel.CheckInDate = this.CheckinDate;
            reservationModel.ContactNumber = this.CustomerContactNumber;
            reservationModel.CustomerName = this.CustomerName;
            List<TableModel> selectedTables = this.GetSelectedTables();
            if (selectedTables != null)
            {
                foreach (TableModel tb in selectedTables)
                {
                    reservationModel.Table.Add(tb);
                }
            }
            reservationModel.PartyOf = this.PartyOf;
            return reservationModel;
        }

        /// <summary>
        /// Create a IReservation object for new reservation
        /// </summary>
        /// <param name="reservationModel">reservationModel obj</param>
        /// <returns>IReservation object</returns>
        private  IReservation CreateReservation(ReservationModel reservationModel)
        {
            IReservation reservation = null;
            if (reservationModel != null)
            {
                //get IReservation object from reservationservice
                reservation = _reservationService.GetReservationObject();
                //set information the object
                reservationModel.ReservationObj = reservation;
                reservation.CheckInDate = reservationModel.CheckInDate;
                reservation.ContactNumber = reservationModel.ContactNumber;
                reservation.CustomerName = reservationModel.CustomerName;
                reservation.Occupants = reservationModel.PartyOf;
                foreach (TableModel tb in reservationModel.Table)
                {
                    ITable tableObj = _tableService.GetTableObject();
                    tableObj.Id = tb.TableID;
                    tableObj.MaxOccupancy = tb.TableOccupancy;
                    _reservationService.SetTableObjectOnReservation(tableObj, reservation);
                }
            }
            return reservation;
        }

        /// <summary>
        /// Get tables selected by user in the ist box
        /// </summary>
        /// <returns></returns>
        private List<TableModel> GetSelectedTables()
        {
            List<TableModel> selectedTables = null;
            if (this.Tables != null)
            {
                selectedTables = this.Tables.Where(t => t.IsTableSelected).ToList();
            }
            return selectedTables;
        }

        /// <summary>
        /// Coammd fr cancel button
        /// </summary>
        /// <param name="obj">command paramter</param>
        private void ExecuteCancelCommand(object obj)
        {
            this.CloseWindow();
        }

        /// <summary>
        /// Closes window
        /// </summary>
        private void CloseWindow()
        {
            if (this.ReservationsView != null)
            {
                this.ReservationsView.Close();
            }
        }

        /// <summary>
        /// Method to publish the RefreshEvent for refreshing reservation data.
        /// </summary>
        private void RefreshReservationData()
        {
            _eventAggregtor.GetEvent<RefreshEvent>().Publish(true);
        }

        /// <summary>
        /// Method to update UI components with reservation information for Edit workflow.
        /// </summary>
        /// <param name="selectedReservationModel">ReservationModel obj</param>
        private void LoadScreenWithSelectedReservationModelData(ReservationModel selectedReservationModel)
        {
            this.CustomerName = selectedReservationModel.CustomerName;
            this.CustomerContactNumber = selectedReservationModel.ContactNumber;
            this.CheckinDate = selectedReservationModel.CheckInDate;
            this.PartyOf = selectedReservationModel.PartyOf;
            foreach (TableModel tb in this.Tables)
            {
                if (selectedReservationModel.Table.Where(t => t.TableID == tb.TableID).Count() == 1)
                {
                    tb.IsTableSelected = true;
                }
                else
                {
                    tb.IsTableSelected = false;
                }
            }
        }

        /// <summary>
        /// Method to update reservation object
        /// </summary>
        /// <param name="selectedReservationModel">ReservationModel obj</param>
        private void UpdateReservationObject(ReservationModel selectedReservationModel)
        {
            selectedReservationModel.ReservationObj.CheckInDate = this.CheckinDate;
            selectedReservationModel.ReservationObj.ContactNumber = this.CustomerContactNumber;
            selectedReservationModel.ReservationObj.CustomerName = this.CustomerName;
            List<TableModel> selectedTables = this.GetSelectedTables();
            if (selectedTables != null && selectedTables.Count > 0)
            {
                _reservationService.ClearTablesOnReservation(selectedReservationModel.ReservationObj);
                foreach (TableModel tb in selectedTables)
                {
                    ITable tableObj = _tableService.GetTableObject();
                    tableObj.Id = tb.TableID;
                    tableObj.MaxOccupancy = tb.TableOccupancy;
                    _reservationService.SetTableObjectOnReservation(tableObj, selectedReservationModel.ReservationObj);
                }
            }
            selectedReservationModel.ReservationObj.Occupants = this.PartyOf;
        }

        /// <summary>
        /// Edit and save reservation
        /// </summary>
        /// <param name="selectedReservationModel">ReservationModel obj</param>
        private void EditReservation(ReservationModel selectedReservationModel)
        {
            //update reservation object
            this.UpdateReservationObject(selectedReservationModel);
            //edit reservation object thru ReservationService
            _reservationService.EditReservation(selectedReservationModel.ReservationObj);
            bool isSuccess = this.SaveReservation();
            if (isSuccess)
            {
                //referesh data after edit
                this.RefreshReservationData();
                MessageBox.Show(Resource.ReservationEditSuccessMsg);
            }
        }

        /// <summary>
        /// Remove reservation
        /// </summary>
        private void RemoveReservation()
        {
            //remove reservation thru reservationservice
            _reservationService.RemoveReservation(this.SelectedReservationModel.ReservationObj);
            //save 
            bool isSuccess = this.SaveReservation();
            if (isSuccess)
            {
                this.RefreshReservationData();
                MessageBox.Show(Resource.ReservationDeleteSuccessMsg);
            }
        }

        /// <summary>
        /// Save reservation xml file
        /// </summary>
        /// <returns>boolean flag</returns>
        private bool SaveReservation()
        {
            bool isSuccess = false;
            try
            {
                //save reservation xml file
               isSuccess =  _reservationService.SaveReservation(SettingsHelper.ReservationsXMLFilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Resource.ErrorWhileSavingReservationMsg);
                //TODO: LOG
            }
            return isSuccess;
        }

        /// <summary>
        /// Validation to check if reservation time falls btween 10am to 10pm.
        /// </summary>
        /// <returns>boolean flag</returns>
        private bool CheckIfReservationTimeFallsInRange()
        {
            bool isReservationTimeOk = false;
            TimeSpan openTime = DateTime.Parse("10:00 AM").TimeOfDay;
            TimeSpan closeTime = DateTime.Parse("10:00 PM").TimeOfDay;
            isReservationTimeOk = (this.CheckinDate.Date == DateTime.Today || this.CheckinDate.Date > DateTime.Today)
                                    && this.CheckinDate.TimeOfDay >= openTime && this.CheckinDate.TimeOfDay <= closeTime;
            return isReservationTimeOk;
        }

        /// <summary>
        /// Validation to check if table is selected
        /// </summary>
        /// <returns>boolean flag</returns>
        private bool CheckIfTableIsSelected()
        {
            bool isTableSelected = false;
            List<TableModel> selectedTables = this.GetSelectedTables();
            if (selectedTables != null && selectedTables.Count > 0)
            {
                isTableSelected = true;
            }
            return isTableSelected;
        }

        /// <summary>
        /// Method to get booked tables for today for a particular checkin time
        /// </summary>
        /// <returns></returns>
        private List<ITable> GetBookedTables()
        {
            List<IReservation> reservations = _reservationService.GetReservations(SettingsHelper.ReservationsXMLFilePath);
            List<ITable> bookedTables = new List<ITable>();
            
                foreach (var reservation in reservations)
                {
                    foreach (var bookedTable in reservation.Table)
                    {
                        if (reservation.CheckInDate.Date == this.CheckinDate.Date &&
                            (reservation.CheckInDate.TimeOfDay.Add(new TimeSpan(1,0,0)) <= this.CheckinDate.TimeOfDay))
                        {
                            bookedTables.Add(bookedTable);
                        }
                    }
               
            }
                return bookedTables;
        }

        /// <summary>
        /// Validation to check if selected table is already booked
        /// </summary>
        /// <returns>boolean flag</returns>
        private bool CheckIfSelectedTablesAreBooked()
        {
            bool areTablesBooked = false;
            List<TableModel> selectedTables = this.GetSelectedTables();
            List<ITable> bookedTables = this.GetBookedTables();
            if (selectedTables != null)
            {
                foreach (var tb in selectedTables)
                {
                    areTablesBooked = bookedTables.Any(t => t.Id == tb.TableID );
                    break;
                }
            }
            return areTablesBooked;
        }

        /// <summary>
        /// Validation to check if tables booked can accomodate the party 
        /// </summary>
        /// <returns></returns>
        private bool CheckIfTablesAndPartyMatch()
        {
            bool isMatch = false;
            int tableOccupancy = this.Tables.Where(t => t.IsTableSelected).Sum(s => s.TableOccupancy);
            if (tableOccupancy >= this.PartyOf)
            {
                isMatch = true;
            }
            return isMatch;
        }
        
        #endregion

        #region Public Methods

        /// <summary>
        /// Method to update UI for editig reservation
        /// </summary>
        public void LoadEditReservation()
        {
            this.LoadScreenWithSelectedReservationModelData(this.SelectedReservationModel);
        }

        /// <summary>
        /// Method to delete reservation
        /// </summary>
        public void DeleteReservation()
        {
            this.RemoveReservation();
        }

        #endregion

        #region IDataErrorInfo

        /// <summary>
        /// Error message
        /// </summary>
        public string Error
        {
            get 
            {
                return _errorMsg;
            }
        }

        /// <summary>
        /// Validates input data as triggered by binding 
        /// </summary>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public string this[string propertyName]
        {
            get
            {
                return Validate(propertyName);
            }
        }

        /// <summary>
        /// Validates the input 
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        private string Validate(string propertyName)
        {
            string validationMessage = string.Empty;
            switch (propertyName)
            {
                case "CustomerName":
                    if (string.IsNullOrEmpty(this.CustomerName))
                    {
                        validationMessage = "Customer name cannot be empty";
                    }
                    break;
                case "CustomerContactNumber":
                    if (string.IsNullOrEmpty(this.CustomerContactNumber) 
                        || !Regex.Match(this.CustomerContactNumber, @"^(\+\d{1,2}\s)?\(?\d{3}\)?\d{3}\d{4}$").Success)
                    {
                        validationMessage = "Invalid customer contact number";
                    }
                    break;
                case "PartyOf":
                    if (this.PartyOf <= 0)
                    {
                        validationMessage = "No. of occupants invalid";
                    }
                    break;
            }
            return validationMessage;
        }

        #endregion
    }
}
