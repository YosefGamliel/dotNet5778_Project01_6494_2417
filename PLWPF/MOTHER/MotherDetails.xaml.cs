using PLWPF.MOTHER;
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
    /// Interaction logic for MotherDetails.xaml
    /// </summary>
    public partial class MotherDetails : Window
    {
        public MotherDetails()
        {
            InitializeComponent();
        }

        private void ADDMOTHERWINDOW(object sender, RoutedEventArgs e)
        {
            ADDMOTHER aDDMOTHERWINDOW = new ADDMOTHER();
            aDDMOTHERWINDOW.ShowDialog();
        }

        private void REMOVEMOTHERWINDOW(object sender, RoutedEventArgs e)
        {

            REMOVEMOTHER rEMOVEMOTHERWINDOW = new REMOVEMOTHER();
            rEMOVEMOTHERWINDOW.ShowDialog();
        }

        private void UPDATEMOTHERWINDOW(object sender, RoutedEventArgs e)
        {
            UPDATEMOTHER uPDATEMOTHERWINDOW = new UPDATEMOTHER();
            uPDATEMOTHERWINDOW.ShowDialog();
        }

        private void ListOfMotherWindow(object sender, RoutedEventArgs e)
        {
            ListOfMother ListOfMotherPage = new ListOfMother();
            ListOfMotherPage.ShowDialog();
        }
    }
}
