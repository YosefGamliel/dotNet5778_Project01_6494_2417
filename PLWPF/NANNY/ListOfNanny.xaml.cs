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
namespace PLWPF.NANNY
{
    /// <summary>
    /// Interaction logic for ListOfNanny.xaml
    /// </summary>
    public partial class ListOfNanny : Window
    {
        List<Nanny> list = new List<Nanny>();
        IBL bl;
        public ListOfNanny()
        {
            InitializeComponent();
            if(bl == null)
                bl = new BL_imp();
            list = bl.getNannyList();
            ListOfNANNY.ItemsSource = list;
        }
    }
}
