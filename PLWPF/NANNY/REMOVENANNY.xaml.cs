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
        Nanny nanny;
        IBL bl;
        public REMOVENANNY()
        {
            InitializeComponent();
            if(bl==null)
                bl=new BL_imp();
            nanny = new Nanny();
            this.DataContext = nanny;
            //foreach (var item in bl.getNannyList())
            //{
            //    ComboBoxItem newItem = new ComboBoxItem();
            //    newItem.Content = item.FirstName +"  " + item.LastName;
            //    Nannysname.Items.Add(newItem);
            //}

            this.Nannysname.ItemsSource = bl.getNannyList();
          //  this.Nannysname.DisplayMemberPath = "FirstName + LastName";
          //  this.Nannysname.SelectedValuePath = "Id";

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            bl.removeNanny((Nanny)Nannysname.SelectedItem);
        }
    }
}
