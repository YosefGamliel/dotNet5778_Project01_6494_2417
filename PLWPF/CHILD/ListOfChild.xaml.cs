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

namespace PLWPF.CHILD
{
    /// <summary>
    /// Interaction logic for ListOfChild.xaml
    /// </summary>
    public partial class ListOfChild : Window
    {
        List<Child> list = new List<Child>();
        IBL bl;
        public ListOfChild()
        {
            InitializeComponent();
            if (bl == null)
                bl = new BL_imp();
            list = bl.getChildList();
            
            ListOfChilds.ItemsSource = list;
        }

     
    }
}
