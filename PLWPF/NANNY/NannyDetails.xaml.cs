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
    /// Interaction logic for NannyDetails.xaml
    /// </summary>
    public partial class NannyDetails : Window
    {
        public NannyDetails()
        {
            InitializeComponent();
        }

        private void ADDNANNYWINDOW(object sender, RoutedEventArgs e)
        {
            ADDNANNY aDDNANNYWINDOWS = new ADDNANNY();
            aDDNANNYWINDOWS.ShowDialog();
        }

        private void REMOVENANNYWINDOW(object sender, RoutedEventArgs e)
        {
            REMOVENANNY rEMOVENANNYWINDOWS = new REMOVENANNY();
            rEMOVENANNYWINDOWS.ShowDialog();
        }

        private void UPDATENANNYWINDOW(object sender, RoutedEventArgs e)
        {
            UPDATENANNY uPDATENANNYWINDOWS = new UPDATENANNY();
            uPDATENANNYWINDOWS.ShowDialog();
        }
    }
}
