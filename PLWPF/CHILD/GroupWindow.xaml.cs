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
        IEnumerable<IGrouping<int, Child>> ChildGroup;
        IBL bl;
        public GroupWindow()
        {
            InitializeComponent();
            if (bl == null)
                bl = new BL_imp();
        }

        void func()
        {
            ChildGroup = MyFunctions.ChildByAge();
            foreach (var item in ChildGroup)
            {
                keysComboBox.Items.Add(item.Key);
            }
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (var item in ChildGroup)
            {if (item.Key == (int)keysComboBox.SelectedItem)
                    ChildView.ItemsSource = item;

            }
        }
    }
}
