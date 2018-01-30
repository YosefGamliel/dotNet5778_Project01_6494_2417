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
namespace PLWPF.CHILD
{
    /// <summary>
    /// Interaction logic for GroupWindow.xaml
    /// </summary>
    public partial class GroupWindow : Window
    {
        IEnumerable<IGrouping<int, Child>> ChildGroupId;
        IEnumerable<IGrouping<String, Child>> ChildGroupMother;
        IBL bl;
        public GroupWindow()
        {
            InitializeComponent();
            if (bl == null)
                bl = new BL_imp();
            KeyID();
            keyMother();
        }
        private void keyMother()
        {
            ChildGroupMother = MyFunctions.ChildByMother();
            Mother mom;
            foreach (var item in ChildGroupMother) //show the mothers
            {
                mom = MyFunctions.FindMotherById(item.Key);
                ComboBoxItem combo = new ComboBoxItem();
                combo.Content = "ID: " + mom.Id + ", First Name: " + mom.FirstName + ", Last Name: " + mom.LastName;
                keyByMother.Items.Add(combo);
            }
        }
        private void KeyID()
        {
            ChildGroupId = MyFunctions.ChildByAge();
            
            foreach (var item in ChildGroupId)
            {
                keysComboBox.Items.Add(item.Key);
            }
        }
        private void keyByID_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (var item in ChildGroupId)
            {
                if (item.Key == (int)keysComboBox.SelectedItem)
                    ChildView.ItemsSource = item;

            }
        }
        private void keyByMother_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string id = null;
            foreach (var item in ChildGroupMother)
            {
                id = ((string)((ComboBoxItem)keyByMother.SelectedItem).Content).Substring(4,9);
                if (item.Key == id)
                    ByMother.ItemsSource = item;
            }
        }
    }
}
