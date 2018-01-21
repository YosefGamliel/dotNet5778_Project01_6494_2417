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
    /// Interaction logic for REMOVECHILD.xaml
    /// </summary>
    public partial class REMOVECHILD : Window
    {
        Child child = new Child();
        IBL bl;
        public REMOVECHILD()
        {
            InitializeComponent();
            if (bl == null)
                bl = new BL_imp();
            this.Childsname.ItemsSource = bl.getChildList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            child = Childsname.SelectionBoxItem as Child;
            if (child == null)
                throw new Exception("Must Choose Child To Delete");
            //שלוח לפונקציה שיחזיר את הילד עם ה תעודת זהות המתאימה
            
//could'nt be 2 child with same id so the list must be only with one Var
            bl.removeChild(child);
            Close();
        }
    }
}
