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
namespace PLWPF
{
    /// <summary>
    /// Interaction logic for REMOVECONTRACT.xaml
    /// </summary>
    public partial class REMOVECONTRACT : Window
    {
        string toDELETE;
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
            if (toDELETE == null)
                throw new Exception("Must Choose Nanny To Delete");
            //שלוח לפונקציה שיחזיר את חוזה עם ה תעודת זהות המתאימה

            //could'nt be 2 Contracts with same id so the list must be only with one Var
            bl.removeContract(MyFunctions.GetContractsBy(x => (x.ContractID == toDELETE.Substring(9)))[0]);
            toDELETE = null;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            toDELETE = Contractsname.SelectedItem.ToString();

        }
    }
}
