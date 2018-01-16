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
namespace PLWPF
{
    /// <summary>
    /// Interaction logic for ADDNANNY.xaml
    /// </summary>
    public partial class ADDNANNY : Window
    {
        Nanny nanny;
        IBL bl ;
        public ADDNANNY()
        {   
            InitializeComponent();
            nanny = new Nanny();
            bl = new BL_imp();
            this.grid1.DataContext = nanny;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.addNanny(nanny);
                nanny = new Nanny();
                this.grid1.DataContext = nanny;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
