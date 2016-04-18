using Microsoft.Practices.Prism;
using Reservations.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Reservations.Views
{
    /// <summary>
    /// Interaction logic for MainScreenUC.xaml
    /// </summary>
    public partial class MainScreenUC : UserControl
    {


        public MainScreenUC(MainScreenViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;
        }

       

    }
}
