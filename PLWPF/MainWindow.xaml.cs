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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BE;
using BL;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IBL bl;
        public MainWindow()
        {
            InitializeComponent();
            if (bl == null)
                bl = new BL_imp();
            inti();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource nannyViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("nannyViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // nannyViewSource.Source = [generic data source]
        }



        private void MotherWindows(object sender, RoutedEventArgs e)
        {
            MotherDetails MotherDetail = new MotherDetails();
            MotherDetail.ShowDialog();
        }

        private void NannyWindows(object sender, RoutedEventArgs e)
        {
            NannyDetails NannyDetail = new NannyDetails();
            NannyDetail.ShowDialog();
        }

        private void ChildWindow(object sender, RoutedEventArgs e)
        {
            ChildDetails ChildDetail = new ChildDetails();
            ChildDetail.ShowDialog();
        }

        private void ContractWindow(object sender, RoutedEventArgs e)
        {
            ContractDetails ContractDetail = new ContractDetails();
            ContractDetail.ShowDialog();
        }

        private TimeSpan[,] getHourNanny()
        {
            TimeSpan[,] hours = new TimeSpan[6, 2];
            for (int i = 0; i < 3; i++)
            {
                hours[i * 2, 0] = new TimeSpan(14, 35, 00);
                hours[i * 2, 1] = new TimeSpan(20, 35, 00);
            }
            return hours;
        }
        private TimeSpan[,] getHourMother()
        {
            TimeSpan[,] hours = new TimeSpan[6, 2];
            for (int i = 0; i < 3; i++)
            {
                hours[i * 2, 0] = new TimeSpan(17, 00, 00);
                hours[i * 2, 1] = new TimeSpan(20, 00, 00);
            }
            return hours;
        }
        private bool[] getDays()
        {
            bool[] days = new bool[6] { true, false, true, false, true, false };
            return days;
        }
        private void inti()
        {
            DateTime Birth = new DateTime(1991, 2, 3);
            #region NannyExample
            Nanny yafit = new Nanny("307471672", "Batito", "Yafit", "0547951348", "Pashos 29,Beer Sheva,israel",
              Birth, true, 3, 3, 7, 3, 55, true, (float)30.5, 0, getDays(), getHourNanny(), false, null);
            bl.addNanny(yafit);
            Birth = new DateTime(1989, 01, 01);
            Nanny shlomit = new Nanny("308922202", "shlomit", "batito", "0547951349", "Pashos 50,Beer Sheva,israel",
            Birth, false, 1, 2, 6, 3, 55, false, 0, 5000, getDays(), getHourNanny(), true, "good nanny");
            bl.addNanny(shlomit);
            #endregion
            #region MotherExample
            Mother galit = new Mother("309549079", "Gamliel", "galit", "0547951344", "Pashos 40,Beer Sheva,israel", "Pashos 40,Beer Sheva,israel", getDays(), getHourMother(), null);
            bl.addMother(galit);
            Mother hagit = new Mother("314370768", "Brok", "Hagit", "0547951366", "יפתח הגלעדי 49, אשקלון, ישראל", "יפתח הגלעדי 49, אשקלון, ישראל", getDays(), getHourMother(), null);
            bl.addMother(hagit);
            #endregion
            #region ChildExample
            Birth = new DateTime(2017, 05, 05);
            Child sunofgalit = new Child("317383297", "Yosef", "309549079", Birth, false, null);
            bl.addChild(sunofgalit);
            Birth = new DateTime(2017, 04, 04);
            Child sunofhagit = new Child("318000262", "Eliav", "314370768", Birth, true, "needs to take 3 pills a day");
            bl.addChild(sunofhagit);
            #endregion
            #region ContractExample
            Birth = new DateTime(2019, 01, 09);
            DateTime End = new DateTime(2019, 05, 09);
            BE.Contract HagitContractAndYafit = new Contract("307471672", "318000262", true, true, Birth, End);
            bl.addContract(HagitContractAndYafit);
            Birth = new DateTime(2019, 01, 08);
            End = new DateTime(2019, 05, 08);
            BE.Contract GalitContractAndshlomit = new Contract("308922202", "317383297", false, true, Birth, End);
            bl.addContract(GalitContractAndshlomit);
            #endregion ContractExample}
        }

        private void LIMQwindow(object sender, RoutedEventArgs e)
        {
            LinqWindow linqWindow = new LinqWindow();
            linqWindow.ShowDialog();
        }
    }
}
