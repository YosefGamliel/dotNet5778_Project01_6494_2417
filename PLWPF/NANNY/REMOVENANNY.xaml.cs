using GoogleMapsApi;
using GoogleMapsApi.Entities.Directions.Request;
using GoogleMapsApi.Entities.Directions.Response;
using System;
using System.Collections.Generic;
using System.Configuration;
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
using System.Windows.Shapes;
using BL;
using BE;
namespace PLWPF
{
    /// <summary>
    /// Interaction logic for REMOVENANNY.xaml
    /// </summary>
    public partial class REMOVENANNY : Window
    {
        Nanny nanny = new Nanny();
        IBL bl;
        public REMOVENANNY()
        {
            InitializeComponent();
            if (bl == null)
                bl = new BL_imp();
            this.Nannysname.ItemsSource = bl.getNannyList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            nanny = Nannysname.SelectionBoxItem as Nanny;
            if (nanny == null)
                throw new Exception("Must Choose Nanny To Delete");
            bl.removeNanny(nanny);
            Close();
        }
    }
}
