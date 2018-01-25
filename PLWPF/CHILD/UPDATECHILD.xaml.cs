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
    /// Interaction logic for UPDATECHILD.xaml
    /// </summary>
    public partial class UPDATECHILD : Window
    {
        IBL bl;
        Child child;
        private List<string> errorMessage = new List<string>();
        public UPDATECHILD()
        {
            InitializeComponent();
            if (bl == null)
                bl = new BL_imp();
            foreach (var ch in bl.getChildList())
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = "ID: " + ch.Id + ", Name: " + ch.FirstName;
                UpdateChildComboBox.Items.Add(item);
            }
        }
        private void UpdateChildComboBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            string id = (string)((ComboBoxItem)UpdateChildComboBox.SelectedItem).Content;
            child = MyFunctions.GetChildBy(x => x.Id == id.Substring(4, 9))[0];
            grid1.DataContext = child;
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
                if (specialNeedsCheckBox.IsChecked == false)
                    child.InfoSpecialNeeds = "";
                bl.updateChild(child);
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
