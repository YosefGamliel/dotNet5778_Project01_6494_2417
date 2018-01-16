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

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for ChildDetails.xaml
    /// </summary>
    public partial class ChildDetails : Window
    {
        public ChildDetails()
        {
            InitializeComponent();
        }

        private void ADDCHILDWINDOW(object sender, RoutedEventArgs e)
        {

            ADDCHILD ADDCHILDPAGE = new ADDCHILD();
            ADDCHILDPAGE.ShowDialog();
        }

        private void REMOVEWINDOW(object sender, RoutedEventArgs e)
        {
            REMOVECHILD REMOVECHILDPAGE = new REMOVECHILD();
            REMOVECHILDPAGE.ShowDialog();
        }

        private void UPDATEWINDOW(object sender, RoutedEventArgs e)
        {
            UPDATECHILD UPDATECHILDPAGE = new UPDATECHILD();
            UPDATECHILDPAGE.ShowDialog();
        }
    }
}
