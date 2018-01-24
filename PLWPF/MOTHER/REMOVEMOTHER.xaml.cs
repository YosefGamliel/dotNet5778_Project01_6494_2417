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
    /// Interaction logic for REMOVEMOTHER.xaml
    /// </summary>
    public partial class REMOVEMOTHER : Window
    {
        Mother mother = new Mother();
        IBL bl;
        private List<string> errorMessage = new List<string>();
        public REMOVEMOTHER()
        {
            InitializeComponent();
            if (bl == null)
                bl = new BL_imp();
            foreach (var mo in bl.getMotherList())
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = "ID: " + mo.Id + ", First Name: " + mo.FirstName + ", Last Name: " + mo.LastName;
                Mothersname.Items.Add(item);
            }
                //.Select(x=> "ID: "+x.Id+"  Name: "+x.FirstName+" "+x.LastName);
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
                string id = (string)((ComboBoxItem)Mothersname.SelectedItem).Content;
                bl.removeMother(MyFunctions.FindMotherById(id.Substring(4, 9)));
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
