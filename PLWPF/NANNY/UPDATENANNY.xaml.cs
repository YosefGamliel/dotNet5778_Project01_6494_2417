﻿using System;
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
    /// Interaction logic for UPDATENANNY.xaml
    /// </summary>
    public partial class UPDATENANNY : Window
    {
        IBL bl;
        Nanny nanny;
        public UPDATENANNY()
        {
            InitializeComponent();
            if (bl == null)
                bl = new BL_imp();
            nanny = new Nanny();
            foreach (var mo in bl.getNannyList())
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = "ID: " + mo.Id + " Name: " + mo.FirstName + " " + mo.LastName;
                UpdateNannyComboBox.Items.Add(item);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void UpdateNannyComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string id = (string)((ComboBoxItem)UpdateNannyComboBox.SelectedItem).Content;
            nanny = MyFunctions.getNannyById(id.Substring(4, 9));
            grid1.DataContext = nanny;
            addressTextBox.Text = nanny.Address;
            sun.IsChecked = nanny.WorkDays[0];
            mon.IsChecked = nanny.WorkDays[1];
            tus.IsChecked = nanny.WorkDays[2];
            wed.IsChecked = nanny.WorkDays[3];
            thu.IsChecked = nanny.WorkDays[4];
            fri.IsChecked = nanny.WorkDays[5];
           
            if (nanny.WorkDays[0])
            {
                sunTimeStart.Value = new DateTime(nanny.WorkHours[0, 0].Ticks);
                sunTimeEnd.Value = new DateTime(nanny.WorkHours[0, 1].Ticks);
            }
            if (nanny.WorkDays[1])
            {
                monTimeStart.Value = new DateTime(nanny.WorkHours[1, 0].Ticks);
                monTimeEnd.Value = new DateTime(nanny.WorkHours[1, 1].Ticks);
            }
            if (nanny.WorkDays[2])
            {
                tueTimeStart.Value = new DateTime(nanny.WorkHours[2, 0].Ticks);
                tueTimeEnd.Value = new DateTime(nanny.WorkHours[2, 1].Ticks);
            }
            if (nanny.WorkDays[3])
            {
                wedTimeStart.Value = new DateTime(nanny.WorkHours[3, 0].Ticks);
                wedTimeEnd.Value = new DateTime(nanny.WorkHours[3, 1].Ticks);
            }
            if (nanny.WorkDays[4])
            {
                thoTimeStart.Value = new DateTime(nanny.WorkHours[4, 0].Ticks);
                thoTimeEnd.Value = new DateTime(nanny.WorkHours[4, 1].Ticks);
            }
            if (nanny.WorkDays[5])
            {
                friTimeStart.Value = new DateTime(nanny.WorkHours[5, 0].Ticks);
                friTimeEnd.Value = new DateTime(nanny.WorkHours[5, 1].Ticks);
            }
            nanny.Address = addressTextBox.Text;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            this.nanny.Address = addressTextBox.Text;
            bl.updateNanny(nanny);
            Close();
        }
    }
}
