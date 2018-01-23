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
        void keyMother()
        {
            ChildGroupMother = MyFunctions.ChildByMother();
            foreach (var item in ChildGroupMother)
            {
                keyByMother.Items.Add(item.Key);
            }


        }
        void KeyID()
        {
            ChildGroupId = MyFunctions.ChildByAge();
            foreach (var item in ChildGroupId)
            {
                keysComboBox.Items.Add(item.Key);
            }
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (var item in ChildGroupId)
            {if (item.Key == (int)keysComboBox.SelectedItem)
                    ChildView.ItemsSource = item;

            }
        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            foreach (var item in ChildGroupMother)
            {
                if (item.Key == (string)keysComboBox.SelectedItem)
                    ChildView.ItemsSource = item;

            }
        }
    }
}
