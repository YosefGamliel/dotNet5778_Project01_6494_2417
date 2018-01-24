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
    /// Interaction logic for LinqWindow.xaml
    /// </summary>
    public partial class LinqWindow : Window
    {
        List<Child> list = new List<Child>();
        List<Nanny> list1 = new List<Nanny>();
        Mother mother = new Mother();
        IBL bl;
        public LinqWindow()
        {
            InitializeComponent();
            if (bl == null)
                bl = new BL_imp();
            list = MyFunctions.ChildWhithoutContract();
            list1 = MyFunctions.NannyByTAMAT();
            ChildwithoutContract.ItemsSource = list;
            NannyByTMT.ItemsSource = list1;
            foreach (var mo in bl.getMotherList())
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = "ID: " + mo.Id + ", First Name: " + mo.FirstName + ", Last Name: " + mo.LastName;
                motherDistanceComboBox.Items.Add(item);
            }

        }

        private void motherDistanceComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string id = (string)((ComboBoxItem)motherDistanceComboBox.SelectedItem).Content;
            mother = MyFunctions.FindMotherById(id.Substring(4, 9));

            foreach (var item in MyFunctions.NannyByDistance(mother))
                DistanceKey.Items.Add(item.Key);
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (var item in MyFunctions.NannyByDistance(mother))
            {
                if (item.Key == (int)DistanceKey.SelectedItem)
                    NannyByDistance.ItemsSource = item;
            }
        }
    }
}
