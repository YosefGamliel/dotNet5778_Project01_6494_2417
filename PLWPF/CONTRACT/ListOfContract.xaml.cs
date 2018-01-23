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
namespace PLWPF.CONTRACT
{
    /// <summary>
    /// Interaction logic for ListOfContract.xaml
    /// </summary>
    public partial class ListOfContract : Window
    {

        List<Contract> list = new List<Contract>();
        IBL bl;
        public ListOfContract()
        {
            InitializeComponent();
            if (bl == null)
                bl = new BL_imp();
            list = bl.getContractList();
            ListOfContracts.ItemsSource = list;
        }
    }
}
