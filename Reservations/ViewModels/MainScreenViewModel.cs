using Framework;
using Framework.Events;
using Framework.Interfaces;
using Microsoft.Practices.Prism;
using Microsoft.Practices.Prism.Events;
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
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Reservations.ViewModels
{
    /// <summary>
    /// View Model class for MainScreenUC view.
    /// </summary>
    public class MainScreenViewModel : ViewModelBase
    {
        #region Private Variables
        private DelegateCommand _newReservationCommand;
        private bool _isReservationsViewVisible;
        private IReservationService _reservationService;
        private ObservableCollection<ReservationModel> _reservationModelList;
        private ReservationModel _selectedReservationModel;
        private DelegateCommand _editReservationCommand;
        private DelegateCommand _deleteReservationCommand;
        private DelegateCommand _closeCommand;
        private IEventAggregator _eventAggregtor;
        private DelegateCommand _settingsCommand;
        private MainScreenUC _mainScreenView;
        #endregion

        #region Properties

        public ReservationModel SelectedReservationModel
        {
            get { return _selectedReservationModel; }
            set { _selectedReservationModel = value; }
        }

        public ObservableCollection<ReservationModel> ReservationModelList
        {
            get { return _reservationModelList; }
            set { _reservationModelList = value; }
        }

        public bool IsReservationsViewVisible
        {
            get { return _isReservationsViewVisible; }
            set 
            { 
                _isReservationsViewVisible = value;
                this.OnPropertyChanged("IsReservationsViewVisible");
            }
        }

        public DelegateCommand SettingsCommand
        {
            get
            {
                return _settingsCommand = new DelegateCommand(ExecuteSettingsCommand);
            }
        }

        
        public DelegateCommand NewReservationCommand
        {
            get
            {
                return _newReservationCommand = new DelegateCommand(ExecuteNewReservationCommand);
            }
        }

        public DelegateCommand EditReservationCommand
        {
            get
            {
                return _editReservationCommand = new DelegateCommand(ExecuteEditReservationCommand);
            }
        }

        public DelegateCommand DeleteReservationCommand
        {
            get
            {
                return _deleteReservationCommand = new DelegateCommand(ExecuteDeleteReservationCommand);
            }
        }

        public DelegateCommand CloseCommand
        {
            get
            {
                return _closeCommand = new DelegateCommand(ExecuteCloseCommand);
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Creates new MainScreenViewModel object
        /// </summary>
        /// <param name="reservationService">IReservationService injected through prism</param>
        /// <param name="eventAggregator">IEventAggregator injected through prism</param>
        public MainScreenViewModel(IReservationService reservationService,IEventAggregator eventAggregator)
        {
            _eventAggregtor = eventAggregator;
            _eventAggregtor.GetEvent<RefreshEvent>().Subscribe(OnRefreshReservations);
            _eventAggregtor.GetEvent<XMLPathSettingsEvent>().Subscribe(OnXMLFilePathsReceived);
            this.IsReservationsViewVisible = false;
            _reservationService = reservationService;
            _reservationModelList = new ObservableCollection<ReservationModel>();
        }

        #endregion


        #region Private Methods

        /// <summary>
        /// Command to add new reservation
        /// </summary>
        /// <param name="parameter">command parameter</param>
        private void ExecuteNewReservationCommand(object parameter)
        {
            if (CheckIfXMLPathsHaveBeenSet())
            {
                try
                {
                    ReservationsView reservationsView = ((UnityContainer)ServiceLocator.Current.GetInstance<IUnityContainer>()).Resolve<ReservationsView>();
                    ReservationsViewModel reservationsVM = reservationsView.DataContext as ReservationsViewModel;
                    reservationsVM.IsAddNewReservation = true;
                    reservationsVM.ReservationsView = reservationsView;
                    reservationsView.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Resource.TableLoadingErrorMsg);
                }
            }
            else
            {
                MessageBox.Show(Resource.SelectXMLFilePathsMsg);
            }
        }

        /// <summary>
        /// Command for close button
        /// </summary>
        /// <param name="obj"></param>
        private void ExecuteCloseCommand(object obj)
        {
            Application.Current.MainWindow.Close();
        }

        /// <summary>
        /// This method loads todays reservation.
        /// </summary>
        private void LoadTodaysReservations()
        {
            try
            {
                //background worker to isolate the time consuming activity
                BackgroundWorker worker = new BackgroundWorker();
                worker.DoWork += ((o, ea) =>
                    {
                        Thread.Sleep(2000);
                        List<IReservation> reservations = _reservationService.GetReservations(SettingsHelper.ReservationsXMLFilePath);
                        //Using Dispatcher object to update the UI components 
                        _mainScreenView.Dispatcher.Invoke((Action)(() =>
                        {
                            this.CreateReservationModel(reservations);
                            _mainScreenView.busyIndicator.IsBusy = false;
                        }));
                    }
                );
                _mainScreenView.busyIndicator.IsBusy = true;
                //begin the background worker
                worker.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Resource.ReservationsLoadingErrorMsg);
            }
        }

        /// <summary>
        /// Validation method to check if user has chosen Tables.xml and Reservations.xml files.
        /// </summary>
        /// <returns></returns>
        private bool CheckIfXMLPathsHaveBeenSet()
        {
            bool areXMLPathsSet = false;
            if(!string.IsNullOrEmpty(SettingsHelper.ReservationsXMLFilePath) && !string.IsNullOrEmpty(SettingsHelper.TablesXMLFilePath))
            {
                areXMLPathsSet = true;
            }
            return areXMLPathsSet;
        }

        /// <summary>
        /// Creates ReservationModel list to bind to the datagrid.
        /// </summary>
        /// <param name="reservations">reservation list</param>
        private void CreateReservationModel(List<IReservation> reservations)
        {
            foreach (IReservation reservation in reservations)
            {
                ReservationModel reservationModel = new ReservationModel
                {
                    CheckInDate = reservation.CheckInDate,
                    ContactNumber = reservation.ContactNumber,
                    CustomerName = reservation.CustomerName,
                    PartyOf = reservation.Occupants,
                    ReservationObj = reservation
                };
                foreach (ITable table in reservation.Table)
                {
                    reservationModel.Table.Add(new TableModel { TableID = table.Id, TableOccupancy = table.MaxOccupancy });
                }
                ReservationModelList.Add(reservationModel);
            }
        }

        /// <summary>
        /// Command for editing reservation
        /// </summary>
        /// <param name="parameter">command parameter</param>
        private void ExecuteEditReservationCommand(object parameter)
        {
            if (this.SelectedReservationModel == null)
            {
                MessageBox.Show(Resource.SelectReservationToEditMsg);
                return;
            }
            if (CheckIfXMLPathsHaveBeenSet())
            {
                try
                {
                    ReservationsView reservationsView = ((UnityContainer)ServiceLocator.Current.GetInstance<IUnityContainer>()).Resolve<ReservationsView>();
                    ReservationsViewModel reservationsVM = (ReservationsViewModel)reservationsView.DataContext;
                    reservationsVM.IsEditReservation = true;
                    reservationsVM.ReservationsView = reservationsView;
                    reservationsVM.SelectedReservationModel = this.SelectedReservationModel;
                    reservationsVM.LoadEditReservation();
                    reservationsView.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Resource.TableLoadingErrorMsg);
                }
            }
            else
            {
                MessageBox.Show(Resource.SelectXMLFilePathsMsg);
            }
        }

        /// <summary>
        /// Command for Deleting reservation
        /// </summary>
        /// <param name="parameter">command paramter</param>
        private void ExecuteDeleteReservationCommand(object parameter)
        {
            if (this.SelectedReservationModel == null)
            {
                MessageBox.Show(Resource.SelectReservationToDeleteMsg);
                return;
            }
            ReservationsView reservationsView = ((UnityContainer)ServiceLocator.Current.GetInstance<IUnityContainer>()).Resolve<ReservationsView>();
            ReservationsViewModel reservationsVM = (ReservationsViewModel)reservationsView.DataContext;
            reservationsVM.SelectedReservationModel = this.SelectedReservationModel;
            reservationsVM.DeleteReservation();
        }

        /// <summary>
        /// Callback method when RefreshEvent is fired.
        /// </summary>
        /// <param name="payload"></param>
        private void OnRefreshReservations(bool payload)
        {
            if (payload)
            {
                this.ReservationModelList.Clear();
                this.LoadTodaysReservations();
            }
        }

        /// <summary>
        /// Command for settings button.
        /// </summary>
        /// <param name="obj">command paramter</param>
        private void ExecuteSettingsCommand(object obj)
        {
            if (obj != null && obj is MainScreenUC)
            {
                _mainScreenView = obj as MainScreenUC;
            }
            SettingsView settingsView = ((UnityContainer)ServiceLocator.Current.GetInstance<IUnityContainer>()).Resolve<SettingsView>();
            settingsView.ShowDialog();
        }

        /// <summary>
        /// Callback method for XMLFilePaths event.
        /// </summary>
        /// <param name="obj">payload</param>
        private void OnXMLFilePathsReceived(XMLFilePaths obj)
        {
            if (obj != null)
            {
                this.LoadTodaysReservations();                
            }
        }
        #endregion
    }
}
