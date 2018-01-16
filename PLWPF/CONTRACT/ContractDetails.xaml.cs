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
    /// Interaction logic for ContractDetails.xaml
    /// </summary>
    public partial class ContractDetails : Window
    {
        public ContractDetails()
        {
            InitializeComponent();
        }

        private void ADDCONTRACTWINDOW(object sender, RoutedEventArgs e)
        {
            ADDCONTRACT aDDCONTRACTWINDOWS = new ADDCONTRACT ();
            aDDCONTRACTWINDOWS.ShowDialog();
        }

        private void REMOVECONTRACTWINDOW(object sender, RoutedEventArgs e)
        {
            REMOVECONTRACT rEMOVECONTRACTWINDOW = new REMOVECONTRACT();
            rEMOVECONTRACTWINDOW.ShowDialog();
        }

        private void UPDATECONTRACTWINDOW(object sender, RoutedEventArgs e)
        {
            UPDATECONTRACT uPDATECONTRACTWINDOW = new UPDATECONTRACT();
            uPDATECONTRACTWINDOW.ShowDialog();
        }
    }
}
