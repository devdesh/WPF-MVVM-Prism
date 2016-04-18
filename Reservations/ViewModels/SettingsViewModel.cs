using Framework;
using Framework.Events;
using Microsoft.Practices.Prism.Events;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace Reservations.ViewModels
{
    /// <summary>
    /// View Model class for XML File paths
    /// </summary>
    public class SettingsViewModel : ViewModelBase
    {
        #region Private Variables

        private string _tablesXMLFilePath;
        private string _reservationsXMLFilePath;
        private DelegateCommand _folderBrowseCommand;
        private DelegateCommand _okCommand;
        private IEventAggregator _eventAggregator;

        #endregion

        #region Constructor

        /// <summary>
        /// Creates new SettingsViewModel object
        /// </summary>
        /// <param name="eventAggregator">IEventAggregator injected through prism</param>
        public SettingsViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }

        #endregion

        #region Properties

        public DelegateCommand FolderBrowseCommand
        {
            get 
            {
                return _folderBrowseCommand = new DelegateCommand(ExecuteFolderBrowseCommand);
            }
        }

        public DelegateCommand OKCommand
        {
            get
            {
                return _okCommand = new DelegateCommand(ExecuteOKCommand);
            }
        }

       
        public string ReservationsXMLFilePath
        {
            get { return _reservationsXMLFilePath; }
            set 
            { 
                _reservationsXMLFilePath = value;
                this.OnPropertyChanged("ReservationsXMLFilePath");
            }
        }


        public string TablesXMLFilePath
        {
            get { return _tablesXMLFilePath; }
            set 
            {
                _tablesXMLFilePath = value;
                this.OnPropertyChanged("TablesXMLFilePath");
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Command for location xml file paths.
        /// </summary>
        /// <param name="obj"></param>
        private void ExecuteFolderBrowseCommand(object obj)
        {
            string parameter = string.Empty;
            if(obj != null)
                parameter = obj as string;
            OpenFileDialog dialog = new OpenFileDialog();
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK && dialog.FileName != null)
            {
                if (parameter == "Table")
                    this.TablesXMLFilePath = dialog.FileName;
                else if (parameter == "Reservation")
                    this.ReservationsXMLFilePath = dialog.FileName;
            }
        }

        /// <summary>
        /// Command for ok button
        /// </summary>
        /// <param name="obj"></param>
        private void ExecuteOKCommand(object obj)
        {
            if (File.Exists(this.TablesXMLFilePath) && File.Exists(this.ReservationsXMLFilePath) && obj != null)
            {
                SettingsHelper.TablesXMLFilePath = this.TablesXMLFilePath;
                SettingsHelper.ReservationsXMLFilePath = this.ReservationsXMLFilePath;
                _eventAggregator.GetEvent<XMLPathSettingsEvent>().Publish(new XMLFilePaths
                {
                    TablesXMLFilePath = this.TablesXMLFilePath,
                    ReservationsXMLFilePath = this.ReservationsXMLFilePath
                });
                if(obj is Window)
                { 
                    Window settingsWindow = obj as Window;
                    settingsWindow.Close();
                }
            }

        }

        #endregion
    }
}
