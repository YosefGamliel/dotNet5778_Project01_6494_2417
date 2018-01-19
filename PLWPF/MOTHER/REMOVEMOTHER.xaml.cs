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
        Mother mother;
        IBL bl;
        public REMOVEMOTHER()
        {
            InitializeComponent();
            if (bl == null)
                bl = new BL_imp();
            mother = new Mother();
            this.DataContext = mother;
            this.Mothersname.ItemsSource = bl.getMotherList();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            bl.removeMother((Mother)Mothersname.SelectedItem);

        }
    }
}
