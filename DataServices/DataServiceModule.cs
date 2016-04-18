using DataServices;
using Framework.Interfaces;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.ServiceLocation;

namespace DataServices
{
    /// <summary>
    /// Module class for DataServicesModule
    /// </summary>
    public class DataServiceModule : IModule
    {
        #region Private Variables

        private UnityContainer _container;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates new DataServiceModule instance
        /// </summary>
        public DataServiceModule()
        {
            _container = (UnityContainer)ServiceLocator.Current.GetInstance<IUnityContainer>() ;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Initializes module
        /// </summary>
        public void Initialize()
        {
            _container.RegisterType<ITableService, TableService>(new ContainerControlledLifetimeManager());
            _container.RegisterType<IReservationService, ReservationService>(new ContainerControlledLifetimeManager());
        }

        #endregion
    }
}
