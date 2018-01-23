using BE;
using BL;
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

namespace PLWPF.MOTHER
{
    /// <summary>
    /// Interaction logic for ListOfMother.xaml
    /// </summary>
    /// 
    public partial class ListOfMother : Window
    {
        List<Mother> list = new List<Mother>();
        IBL bl;
        public ListOfMother()
        {
            InitializeComponent();
            if (bl == null)
                bl = new BL_imp();
            list = bl.getMotherList();
            ListOfMothers.ItemsSource = list;
        }
    }
}
