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
            foreach (var mo in bl.getMotherList())
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = "ID: " + mo.Id + " Name: " + mo.FirstName + " " + mo.LastName;
                UpdateMotherComboBox.Items.Add(item);
            }
        }

        private void UpdateMotherComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string id = (string) ((ComboBoxItem)UpdateMotherComboBox.SelectedItem).Content;
            mother=MyFunctions.FindMotherById(id.Substring(4, 9));
            grid1.DataContext = mother;
            addressTextBox.Content = mother.Address;


        }

    }
}
