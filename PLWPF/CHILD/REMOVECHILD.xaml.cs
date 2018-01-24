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
    /// Interaction logic for REMOVECHILD.xaml
    /// </summary>
    public partial class REMOVECHILD : Window
    {
        Child child = new Child();
        IBL bl;
        private List<string> errorMessage = new List<string>();
        public REMOVECHILD()
        {
            InitializeComponent();
            if (bl == null)
                bl = new BL_imp();
            foreach (var ch in bl.getChildList())
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = "ID: " + ch.Id + " Name: " + ch.FirstName;
                Childsname.Items.Add(item);
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
                string id = (string)((ComboBoxItem)Childsname.SelectedItem).Content;
                bl.removeChild(MyFunctions.GetChildBy(x => x.Id == id.Substring(4, 9))[0]);
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
