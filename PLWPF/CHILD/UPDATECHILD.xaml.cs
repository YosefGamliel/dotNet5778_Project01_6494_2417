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
        public UPDATECHILD()
        {
            InitializeComponent();
            if (bl == null)
                bl = new BL_imp();
            foreach (var ch in bl.getMotherList())
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = "ID: " + ch.Id + " Name: " + ch.FirstName + " " + ch.LastName;
                UpdateChildComboBox.Items.Add(item);
            }
        }
        private void UpdateChildComboBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            string id = (string)((ComboBoxItem)UpdateChildComboBox.SelectedItem).Content;
            child = MyFunctions.GetChildBy(x => x.Id == id)[0];
            grid1.DataContext = child;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bl.updateChild(child);
            Close();
        }
    }
}
