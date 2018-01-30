using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Globalization;
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
    /// Interaction logic for UPDATECONTRACT.xaml
    /// </summary>
    public partial class UPDATECONTRACT : Window
    {
        IBL bl;
        Contract contract;
        private List<string> errorMessage = new List<string>();
        public UPDATECONTRACT()
        {
            InitializeComponent();
            if (bl == null)
                bl = new BL_imp();
            foreach (var co in bl.getContractList()) //show the contracts
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = "Contract ID: " + co.ContractID;
                UpdateContractComboBox.Items.Add(item);
            }
        }

        private void validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                errorMessage.Add((string)e.Error.ErrorContent);
            else
                errorMessage.Remove((string)e.Error.ErrorContent);
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
                bl.updateContract(contract);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateContractComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string id = (string)((ComboBoxItem)UpdateContractComboBox.SelectedItem).Content;
            contract = MyFunctions.GetContractsBy(x => x.ContractID == id.Substring(13, 8))[0];
            grid1.DataContext = contract;
        }
    }
}
