using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Prism.UnityExtensions;
using RestaurantReservationSystem.Views;
using System.Windows;
using Microsoft.Practices.Prism.Modularity;


namespace RestaurantReservationSystem
{
    public class BootStrapper : UnityBootstrapper
    {
        /// <summary>
        /// Create shell instance
        /// </summary>
        /// <returns></returns>
        protected override System.Windows.DependencyObject CreateShell()
        {
            return this.Container.Resolve<Shell>();
        }

        /// <summary>
        /// Configure module catalog
        /// </summary>
        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();
           
        }
        /// <summary>
        /// Configure container
        /// </summary>
        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
        }

        /// <summary>
        /// Create ModuleCatalog through app.config
        /// </summary>
        /// <returns></returns>
        protected override IModuleCatalog CreateModuleCatalog()
        {
            ConfigurationModuleCatalog configCatalog = new ConfigurationModuleCatalog();
            return configCatalog;
        }

        /// <summary>
        /// Initialize shell
        /// </summary>
        protected override void InitializeShell()
        {
            base.InitializeShell();
            App.Current.MainWindow = (Window)this.Shell;
            App.Current.MainWindow.Show();
        }
    }
}
