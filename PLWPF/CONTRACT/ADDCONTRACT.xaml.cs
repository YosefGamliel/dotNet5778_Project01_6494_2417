using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Globalization;
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
    /// Interaction logic for ADDCONTRACT.xaml
    /// </summary>
    public partial class ADDCONTRACT : Window
    {

        Contract contract;
        IBL bl;
        private List<string> errorMessage = new List<string>();
        public ADDCONTRACT()
        {
            InitializeComponent();
            contract = new Contract();
            if (bl == null)
                bl = new BL_imp();
            foreach (var mo in bl.getMotherList()) //show the mothers
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = "ID: " + mo.Id + ", First Name: " + mo.FirstName + ", Last Name: " + mo.LastName;
                motherIDComboBox.Items.Add(item);
            }
            this.grid1.DataContext = contract;
            endDatePicker.SelectedDate = DateTime.Now; //reset to now
            startDatePicker.SelectedDate = DateTime.Now; //reset to now
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource contractViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("contractViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // contractViewSource.Source = [generic data source]
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
                contract.MotherID = ((string)((ComboBoxItem)motherIDComboBox.SelectedItem).Content).Substring(4, 9);
                contract.ChildID = ((string)((ComboBoxItem)childIDComboBox.SelectedItem).Content).Substring(4, 9);
                contract.BabySitterID = ((string)((ComboBoxItem)babySitterIDComboBox.SelectedItem).Content).Substring(4, 9);
                bl.addContract(contract);
                contract = new Contract();
                this.grid1.DataContext = contract;
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

        private void motherIDComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            childIDComboBox.Items.Clear();
            string id = (string)((ComboBoxItem)motherIDComboBox.SelectedItem).Content;
            foreach (var ch in bl.getChildList(MyFunctions.FindMotherById(id.Substring(4, 9)))) //show the childs by the mother id
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = "ID: " + ch.Id + " Name: " + ch.FirstName;
                childIDComboBox.Items.Add(item);
            }
            babySitterIDComboBox.Items.Clear();
            foreach (var nan in MyFunctions.NanniesToMother(MyFunctions.FindMotherById(id.Substring(4, 9)))) //show the nannies by the mother id
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = "ID: " + nan.Id + ", First Name: " + nan.FirstName + ", Last Name: " + nan.LastName;
                babySitterIDComboBox.Items.Add(item);
            }
        }
    }
    public class TrueToFalseConverter : IValueConverter //converter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool boolValue = (bool)value;
            return !boolValue;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class ComboBoxItemToBoolConverter : IValueConverter //converter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
                return true;
            else
                return false;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
