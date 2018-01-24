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
        private List<string> errorMessage = new List<string>();
        public REMOVECONTRACT()
        {
            InitializeComponent();
            if (bl == null)
                bl = new BL_imp();
            foreach (var co in bl.getContractList())
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = "Contract ID: " + co.ContractID;
                Contractsname.Items.Add(item);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (errorMessage.Any())
                {
                    string err = "Exception:";
                    foreach (var item in errorMessage)
                        err += "\n" + item;
                    MessageBox.Show(err);
                    return;
                }
                string id = (string)((ComboBoxItem)Contractsname.SelectedItem).Content;
                bl.removeContract(MyFunctions.GetContractsBy(x => x.ContractID == id.Substring(13, 8))[0]);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                errorMessage.Add((string)e.Error.ErrorContent);
            else
                errorMessage.Remove((string)e.Error.ErrorContent);
        }
    }
}
