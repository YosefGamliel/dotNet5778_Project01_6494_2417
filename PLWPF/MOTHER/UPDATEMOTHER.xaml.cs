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
using BL;
using BE;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for UPDATEMOTHER.xaml
    /// </summary>
    public partial class UPDATEMOTHER : Window
    {
        IBL bl;
        Mother mother;
        private List<string> errorMessage = new List<string>();
        public UPDATEMOTHER()
        {
            InitializeComponent();
            if (bl == null)
                bl = new BL_imp();
            mother = new Mother();
            foreach (var mo in bl.getMotherList())
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = "ID: " + mo.Id + ", First Name: " + mo.FirstName + ", Last Name: " + mo.LastName;
                UpdateMotherComboBox.Items.Add(item);
            }
        }

        private void UpdateMotherComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string id = (string)((ComboBoxItem)UpdateMotherComboBox.SelectedItem).Content;
            mother = MyFunctions.FindMotherById(id.Substring(4, 9));
            grid1.DataContext = mother;
            addressTextBox.Text = mother.Address;
            addressNannyTextBox.Text = mother.AreaNanny;
            sun.IsChecked = mother.NeedNanny[0];
            mon.IsChecked = mother.NeedNanny[1];
            tus.IsChecked = mother.NeedNanny[2];
            wed.IsChecked = mother.NeedNanny[3];
            thu.IsChecked = mother.NeedNanny[4];
            fri.IsChecked = mother.NeedNanny[5];

            if (mother.NeedNanny[0])
            {
                sunTimeStart.Text = new DateTime(mother.WorkHours[0, 0].Ticks).ToShortTimeString();
                sunTimeEnd.Text = new DateTime(mother.WorkHours[0, 1].Ticks).ToShortTimeString();
            }
            if (mother.NeedNanny[1])
            {
                monTimeStart.Text = new DateTime(mother.WorkHours[1, 0].Ticks).ToShortTimeString();
                monTimeEnd.Text = new DateTime(mother.WorkHours[1, 1].Ticks).ToShortTimeString();
            }
            if (mother.NeedNanny[2])
            {
                tueTimeStart.Text = new DateTime(mother.WorkHours[2, 0].Ticks).ToShortTimeString();
                tueTimeEnd.Text = new DateTime(mother.WorkHours[2, 1].Ticks).ToShortTimeString();
            }
            if (mother.NeedNanny[3])
            {
                wedTimeStart.Text = new DateTime(mother.WorkHours[3, 0].Ticks).ToShortTimeString();
                wedTimeEnd.Text = new DateTime(mother.WorkHours[3, 1].Ticks).ToShortTimeString();
            }
            if (mother.NeedNanny[4])
            {
                thoTimeStart.Text = new DateTime(mother.WorkHours[4, 0].Ticks).ToShortTimeString();
                thoTimeEnd.Text = new DateTime(mother.WorkHours[4, 1].Ticks).ToShortTimeString();
            }
            if (mother.NeedNanny[5])
            {
                friTimeStart.Text = new DateTime(mother.WorkHours[5, 0].Ticks).ToShortTimeString();
                friTimeEnd.Text = new DateTime(mother.WorkHours[5, 1].Ticks).ToShortTimeString();
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
                mother.Address = addressTextBox.Text;
                mother.AreaNanny = addressNannyTextBox.Text;
                mother.NeedNanny[0] = sun.IsChecked.Value;
                mother.NeedNanny[1] = mon.IsChecked.Value;
                mother.NeedNanny[2] = tus.IsChecked.Value;
                mother.NeedNanny[3] = wed.IsChecked.Value;
                mother.NeedNanny[4] = thu.IsChecked.Value;
                mother.NeedNanny[5] = fri.IsChecked.Value;
                if (mother.NeedNanny[0])
                {
                    mother.WorkHours[0, 0] = TimeSpan.Parse(sunTimeStart.Text);
                    mother.WorkHours[0, 1] = TimeSpan.Parse(sunTimeEnd.Text);
                }
                else
                {
                    mother.WorkHours[0, 0] = TimeSpan.Zero;
                    mother.WorkHours[0, 1] = TimeSpan.Zero;
                }
                if (mother.NeedNanny[1])
                {
                    mother.WorkHours[1, 0] = TimeSpan.Parse(monTimeStart.Text);
                    mother.WorkHours[1, 1] = TimeSpan.Parse(monTimeEnd.Text);
                }
                else
                {
                    mother.WorkHours[1, 0] = TimeSpan.Zero;
                    mother.WorkHours[1, 1] = TimeSpan.Zero;
                }
                if (mother.NeedNanny[2])
                {
                    mother.WorkHours[2, 0] = TimeSpan.Parse(tueTimeStart.Text);
                    mother.WorkHours[2, 1] = TimeSpan.Parse(tueTimeEnd.Text);
                }
                else
                {
                    mother.WorkHours[2, 0] = TimeSpan.Zero;
                    mother.WorkHours[2, 1] = TimeSpan.Zero;
                }
                if (mother.NeedNanny[3])
                {
                    mother.WorkHours[3, 0] = TimeSpan.Parse(wedTimeStart.Text);
                    mother.WorkHours[3, 1] = TimeSpan.Parse(wedTimeEnd.Text);
                }
                else
                {
                    mother.WorkHours[3, 0] = TimeSpan.Zero;
                    mother.WorkHours[3, 1] = TimeSpan.Zero;
                }
                if (mother.NeedNanny[4])
                {
                    mother.WorkHours[4, 0] = TimeSpan.Parse(thoTimeStart.Text);
                    mother.WorkHours[4, 1] = TimeSpan.Parse(thoTimeEnd.Text);
                }
                else
                {
                    mother.WorkHours[4, 0] = TimeSpan.Zero;
                    mother.WorkHours[4, 1] = TimeSpan.Zero;
                }
                if (mother.NeedNanny[5])
                {
                    mother.WorkHours[5, 0] = TimeSpan.Parse(friTimeStart.Text);
                    mother.WorkHours[5, 1] = TimeSpan.Parse(friTimeEnd.Text);
                }
                else
                {
                    mother.WorkHours[5, 0] = TimeSpan.Zero;
                    mother.WorkHours[5, 1] = TimeSpan.Zero;
                }
                bl.updateMother(mother);
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
