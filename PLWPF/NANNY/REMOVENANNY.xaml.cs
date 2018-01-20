using GoogleMapsApi;
using GoogleMapsApi.Entities.Directions.Request;
using GoogleMapsApi.Entities.Directions.Response;
using System;
using System.Collections.Generic;
using System.Configuration;
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
    /// Interaction logic for REMOVENANNY.xaml
    /// </summary>
    public partial class REMOVENANNY : Window
    {
        string toDELETE;
        IBL bl;
        public REMOVENANNY()
        {
            InitializeComponent();
            if(bl==null)
                bl=new BL_imp();
            this.Nannysname.ItemsSource = bl.getNannyList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (toDELETE == null)
                throw new Exception("Must Choose Nanny To Delete");

           bl.removeNanny(MyFunctions.getNannyById(toDELETE.Substring(9)));
           toDELETE = null;

        }
        /// <summary>
        /// הסבר : הכומבו בוקס לא מחזיר מסוג עוזרת אלא את ה העמסת אופרטור טו סטרינג ולכן מה עשיתי ? 
        /// לקחתי את המחרוזת חתכתי את ה התעודת זהות שלה 
        /// וחיפשתי לפיה ומחקתי
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           toDELETE =Nannysname.SelectedItem.ToString();
        }
    }
}
