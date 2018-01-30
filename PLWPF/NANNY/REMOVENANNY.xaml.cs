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
        private List<string> errorMessage = new List<string>();
        public REMOVENANNY()
        {
            InitializeComponent();
            if (bl == null)
                bl = new BL_imp();
            foreach (var nan in bl.getNannyList()) //show the nannies
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = "ID: " + nan.Id + ", First Name: " + nan.FirstName + ", Last Name: " + nan.LastName;
                Nannysname.Items.Add(item);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (errorMessage.Any())
                {
                    string err = "Exception:";
                    foreach (var item in errorMessage)
                        err += "\n" + item;
                    MessageBox.Show(err);
                    return;
                }
                string id = (string)((ComboBoxItem)Nannysname.SelectedItem).Content;
                bl.removeNanny(MyFunctions.GetNannyBy(x => x.Id == id.Substring(4, 9))[0]);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                errorMessage.Add((string)e.Error.ErrorContent);
            else
                errorMessage.Remove((string)e.Error.ErrorContent);
        }
    }
}
