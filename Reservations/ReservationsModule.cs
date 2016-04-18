using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using Reservations.ViewModels;
using Reservations.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservations
{
    /// <summary>
    /// Module class for ReservationsModule
    /// </summary>
    public class ReservationsModule : IModule
    {
        #region Private Variables

        private RegionViewRegistry _regionRegistry;
        private UnityContainer _container;

        #endregion

        #region Constructor
        /// <summary>
        /// Creates new ReservationsModule obj
        /// </summary>
        /// <param name="regionViewRegistry">RegionViewRegistry inected thru prism</param>
        public ReservationsModule(RegionViewRegistry regionViewRegistry)
        {
            _regionRegistry = regionViewRegistry;
            _container = (UnityContainer)ServiceLocator.Current.GetInstance<IUnityContainer>();

        }

        #endregion


        #region Public Methods
        /// <summary>
        /// Initializes module
        /// </summary>
        public void Initialize()
        {
            //_container.RegisterInstance(typeof(ReservationsViewModel),new ContainerControlledLifetimeManager());
            _regionRegistry.RegisterViewWithRegion("Main Region", typeof(MainScreenUC));
            _container.RegisterInstance(typeof(ReservationsView));
            _container.RegisterInstance(typeof(SettingsView));
        }

        #endregion
    }
}
