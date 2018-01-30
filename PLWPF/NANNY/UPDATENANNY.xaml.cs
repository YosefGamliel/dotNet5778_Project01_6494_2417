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
namespace PLWPF
{
    /// <summary>
    /// Interaction logic for UPDATENANNY.xaml
    /// </summary>
    public partial class UPDATENANNY : Window
    {
        IBL bl;
        Nanny nanny;
        private List<string> errorMessage = new List<string>();
        public UPDATENANNY()
        {
            InitializeComponent();
            if (bl == null)
                bl = new BL_imp();
            nanny = new Nanny();
            foreach (var nan in bl.getNannyList()) //show the nannies
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = "ID: " + nan.Id + ", First Name: " + nan.FirstName + ", Last Name: " + nan.LastName;
                UpdateNannyComboBox.Items.Add(item);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void UpdateNannyComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string id = (string)((ComboBoxItem)UpdateNannyComboBox.SelectedItem).Content;
            nanny = MyFunctions.getNannyById(id.Substring(4, 9));
            grid1.DataContext = nanny;
            #region אתחולים ידנית
            addressTextBox.Text = nanny.Address;
            sun.IsChecked = nanny.WorkDays[0];
            mon.IsChecked = nanny.WorkDays[1];
            tus.IsChecked = nanny.WorkDays[2];
            wed.IsChecked = nanny.WorkDays[3];
            thu.IsChecked = nanny.WorkDays[4];
            fri.IsChecked = nanny.WorkDays[5];

            if (nanny.WorkDays[0])
            {
                sunTimeStart.Text = new DateTime(nanny.WorkHours[0, 0].Ticks).ToShortTimeString();
                sunTimeEnd.Text = new DateTime(nanny.WorkHours[0, 1].Ticks).ToShortTimeString();
            }
            if (nanny.WorkDays[1])
            {
                monTimeStart.Text = new DateTime(nanny.WorkHours[1, 0].Ticks).ToShortTimeString();
                monTimeEnd.Text = new DateTime(nanny.WorkHours[1, 1].Ticks).ToShortTimeString();
            }
            if (nanny.WorkDays[2])
            {
                tueTimeStart.Text = new DateTime(nanny.WorkHours[2, 0].Ticks).ToShortTimeString();
                tueTimeEnd.Text = new DateTime(nanny.WorkHours[2, 1].Ticks).ToShortTimeString();
            }
            if (nanny.WorkDays[3])
            {
                wedTimeStart.Text = new DateTime(nanny.WorkHours[3, 0].Ticks).ToShortTimeString();
                wedTimeEnd.Text = new DateTime(nanny.WorkHours[3, 1].Ticks).ToShortTimeString();
            }
            if (nanny.WorkDays[4])
            {
                thoTimeStart.Text = new DateTime(nanny.WorkHours[4, 0].Ticks).ToShortTimeString();
                thoTimeEnd.Text = new DateTime(nanny.WorkHours[4, 1].Ticks).ToShortTimeString();
            }
            if (nanny.WorkDays[5])
            {
                friTimeStart.Text = new DateTime(nanny.WorkHours[5, 0].Ticks).ToShortTimeString();
                friTimeEnd.Text = new DateTime(nanny.WorkHours[5, 1].Ticks).ToShortTimeString();
            }
            #endregion
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
                #region אתחולים ידנית
                nanny.Address = addressTextBox.Text;
                nanny.WorkDays[0] = sun.IsChecked.Value;
                nanny.WorkDays[1] = mon.IsChecked.Value;
                nanny.WorkDays[2] = tus.IsChecked.Value;
                nanny.WorkDays[3] = wed.IsChecked.Value;
                nanny.WorkDays[4] = thu.IsChecked.Value;
                nanny.WorkDays[5] = fri.IsChecked.Value;
                if (nanny.WorkDays[0])
                {
                    nanny.WorkHours[0, 0] = TimeSpan.Parse(sunTimeStart.Text);
                    nanny.WorkHours[0, 1] = TimeSpan.Parse(sunTimeEnd.Text);
                }
                else //reset the time
                {
                    nanny.WorkHours[0, 0] = TimeSpan.Zero;
                    nanny.WorkHours[0, 1] = TimeSpan.Zero;
                }
                if (nanny.WorkDays[1])
                {
                    nanny.WorkHours[1, 0] = TimeSpan.Parse(monTimeStart.Text);
                    nanny.WorkHours[1, 1] = TimeSpan.Parse(monTimeEnd.Text);
                }
                else
                {
                    nanny.WorkHours[1, 0] = TimeSpan.Zero;
                    nanny.WorkHours[1, 1] = TimeSpan.Zero;
                }
                if (nanny.WorkDays[2])
                {
                    nanny.WorkHours[2, 0] = TimeSpan.Parse(tueTimeStart.Text);
                    nanny.WorkHours[2, 1] = TimeSpan.Parse(tueTimeEnd.Text);
                }
                else
                {
                    nanny.WorkHours[2, 0] = TimeSpan.Zero;
                    nanny.WorkHours[2, 1] = TimeSpan.Zero;
                }
                if (nanny.WorkDays[3])
                {
                    nanny.WorkHours[3, 0] = TimeSpan.Parse(wedTimeStart.Text);
                    nanny.WorkHours[3, 1] = TimeSpan.Parse(wedTimeEnd.Text);
                }
                else
                {
                    nanny.WorkHours[3, 0] = TimeSpan.Zero;
                    nanny.WorkHours[3, 1] = TimeSpan.Zero;
                }
                if (nanny.WorkDays[4])
                {
                    nanny.WorkHours[4, 0] = TimeSpan.Parse(thoTimeStart.Text);
                    nanny.WorkHours[4, 1] = TimeSpan.Parse(thoTimeEnd.Text);
                }
                else
                {
                    nanny.WorkHours[4, 0] = TimeSpan.Zero;
                    nanny.WorkHours[4, 1] = TimeSpan.Zero;
                }
                if (nanny.WorkDays[5])
                {
                    nanny.WorkHours[5, 0] = TimeSpan.Parse(friTimeStart.Text);
                    nanny.WorkHours[5, 1] = TimeSpan.Parse(friTimeEnd.Text);
                }
                else
                {
                    nanny.WorkHours[5, 0] = TimeSpan.Zero;
                    nanny.WorkHours[5, 1] = TimeSpan.Zero;
                }
                #endregion
                bl.updateNanny(nanny);
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
