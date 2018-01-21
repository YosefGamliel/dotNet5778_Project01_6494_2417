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
    /// Interaction logic for REMOVECONTRACT.xaml
    /// </summary>
    public partial class REMOVECONTRACT : Window
    {
        Contract contract = new Contract();
        IBL bl;
        public REMOVECONTRACT()
        {
            InitializeComponent();
            if (bl == null)
                bl = new BL_imp();
            this.Contractsname.ItemsSource = bl.getNannyList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            contract = Contractsname.SelectionBoxItem as Contract;
            if (contract == null)
                throw new Exception("Must Choose Contract To Delete");
            //שלוח לפונקציה שיחזיר את חוזה עם ה תעודת זהות המתאימה

            //could'nt be 2 Contracts with same id so the list must be only with one Var
            bl.removeContract(contract);
            Close();
        }
    }
}
