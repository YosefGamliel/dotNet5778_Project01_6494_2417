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
        public UPDATEMOTHER()
        {
            InitializeComponent();
            if (bl == null)
                bl = new BL_imp();
            mother = new Mother();
            foreach (var mo in bl.getMotherList())
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = "ID: " + mo.Id + " Name: " + mo.FirstName + " " + mo.LastName;
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
                sunTimeStart.Value = new DateTime(mother.WorkHours[0, 0].Ticks);
                sunTimeEnd.Value = new DateTime(mother.WorkHours[0, 1].Ticks);
            }
            if (mother.NeedNanny[1])
            {
                monTimeStart.Value = new DateTime(mother.WorkHours[1, 0].Ticks);
                monTimeEnd.Value = new DateTime(mother.WorkHours[1, 1].Ticks);
            }
            if (mother.NeedNanny[2])
            {
                tueTimeStart.Value = new DateTime(mother.WorkHours[2, 0].Ticks);
                tueTimeEnd.Value = new DateTime(mother.WorkHours[2, 1].Ticks);
            }
            if (mother.NeedNanny[3])
            {
                wedTimeStart.Value = new DateTime(mother.WorkHours[3, 0].Ticks);
                wedTimeEnd.Value = new DateTime(mother.WorkHours[3, 1].Ticks);
            }
            if (mother.NeedNanny[4])
            {
                thoTimeStart.Value = new DateTime(mother.WorkHours[4, 0].Ticks);
                thoTimeEnd.Value = new DateTime(mother.WorkHours[4, 1].Ticks);
            }
            if (mother.NeedNanny[5])
            {
                friTimeStart.Value = new DateTime(mother.WorkHours[5, 0].Ticks);
                friTimeEnd.Value = new DateTime(mother.WorkHours[5, 1].Ticks);
            }
            mother.Address = addressTextBox.Text;
            mother.AreaNanny = addressNannyTextBox.Text;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        { 
            this.mother.Address = addressTextBox.Text;
            this.mother.AreaNanny=addressNannyTextBox.Text;
            this.mother.NeedNanny[0] = sun.IsChecked.Value;
            bl.updateMother(mother);
            Close();
        }
    }
}
