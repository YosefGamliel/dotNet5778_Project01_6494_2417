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
using System.Windows.Shapes;
using BE;
using BL;
using GoogleMapsApi;
using GoogleMapsApi.Entities.PlaceAutocomplete.Request;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for ADDNANNY.xaml
    /// </summary>
    public partial class ADDNANNY : Window
    {
        Nanny nanny;
        IBL bl;
        private List<string> errorMessage = new List<string>();
        public ADDNANNY()
        {
            InitializeComponent();
            nanny = new Nanny();
            if (bl == null)
                bl = new BL_imp();
            this.grid1.DataContext = nanny;
            this.workDay.DataContext = nanny;
            this.time.DataContext = nanny;
            birthdayDatePicker.DataContext = DateTime.Now;
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
                #region איתחולים שלא עובדים עם בינדינג
               nanny.Address = addressTextBox.Text;
               nanny.Birthday = (DateTime)birthdayDatePicker.SelectedDate;
                #endregion
                bl.addNanny(nanny);
                nanny = new Nanny();
                this.grid1.DataContext = nanny;
                this.Close();

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