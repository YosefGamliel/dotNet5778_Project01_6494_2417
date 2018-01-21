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
    /// Interaction logic for ADDMOTHER.xaml
    /// </summary>
    public partial class ADDMOTHER : Window
    {
        Mother mother;
        IBL bl;
        private List<string> errorMessage = new List<string>();
        public ADDMOTHER()
        {
            InitializeComponent();
            mother = new Mother();
            if (bl == null)
                bl = new BL_imp();
            this.grid1.DataContext = mother;
            this.workDay.DataContext = mother;
            this.time.DataContext = mother;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource motherViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("motherViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // motherViewSource.Source = [generic data source]
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
                #region איתחולים שלא עובדים בבינדינג
                mother.Address = addressTextBox.Text;
                mother.AreaNanny = addressNannyTextBox.Text;
                //.Parse(Null)=>return Exception so we check before
                if (mother.NeedNanny[0])
                {
                    mother.WorkHours[0, 0] = TimeSpan.Parse(sunTimeStart.Text);
                    mother.WorkHours[0, 1] = TimeSpan.Parse(sunTimeEnd.Text);
                }
                if (mother.NeedNanny[1])
                {
                    mother.WorkHours[1, 0] = TimeSpan.Parse(monTimeStart.Text);
                    mother.WorkHours[1, 1] = TimeSpan.Parse(monTimeEnd.Text);
                }
                if (mother.NeedNanny[2])
                {
                    mother.WorkHours[2, 0] = TimeSpan.Parse(tueTimeStart.Text);
                    mother.WorkHours[2, 1] = TimeSpan.Parse(tueTimeEnd.Text);
                }
                if (mother.NeedNanny[3])
                {
                    mother.WorkHours[3, 0] = TimeSpan.Parse(wedTimeStart.Text);
                    mother.WorkHours[3, 1] = TimeSpan.Parse(wedTimeEnd.Text);
                }
                if (mother.NeedNanny[4])
                {
                    mother.WorkHours[4, 0] = TimeSpan.Parse(thoTimeStart.Text);
                    mother.WorkHours[4, 1] = TimeSpan.Parse(thoTimeEnd.Text);
                }
                if (mother.NeedNanny[5])
                {
                    mother.WorkHours[5, 0] = TimeSpan.Parse(friTimeStart.Text);
                    mother.WorkHours[5, 1] = TimeSpan.Parse(friTimeEnd.Text);
                }
                #endregion
                bl.addMother(mother);
                mother = new Mother();
                this.grid1.DataContext = mother;
                this.Close();

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
