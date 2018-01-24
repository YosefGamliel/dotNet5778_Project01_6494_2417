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
        private void inti()
        {
            bool[] wd = new bool[6] { true, true, true, true, true, true };
            TimeSpan[,] workH = new TimeSpan[6, 2];
            DateTime Birth = new DateTime(1991, 2, 3);
            for (int i = 0; i < 6; i++)
            {
                workH[i, 0] = new TimeSpan(14, 35, 00);
                workH[i, 1] = new TimeSpan(20, 35, 00);
            }
            #region NannyExample
            Nanny yafit = new Nanny("307471672", "Yafit", "Batito", "0547951348", "Pashos 29,Beer Sheva,israel",
              Birth, true, 3, 3, 20, 3
                , 55, true, (float)30.5, 3500, wd, workH, true, null);
            bl.addNanny(yafit);
            Birth = new DateTime(1989, 01, 01);
            Nanny shlomit = new Nanny("308922202", "shlomit", "batito", "0547951349", "Pashos 50,Beer Sheva,israel",
            Birth, true, 3, 3, 20, 3
              , 55, true, (float)50.5, 5000, wd, workH, true, null);
            bl.addNanny(shlomit);
            #endregion
            #region MotherExample
            Mother galit = new Mother("309549079", "galit", "Gamliel", "0547951344", "Pashos 40,Beer Sheva,israel", "Pashos 40,Beer Sheva,israel", wd, workH, null);
            bl.addMother(galit);
            Mother hagit = new Mother("314370768", "Hagit", "Brok", "0547951366", "Pashos 41,Beer Sheva,israel", "Pashos 41,Beer Sheva,israel", wd, workH, null);
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
            BE.Contract GalitContractAndshlomit = new Contract("308922202", "317383297", true, true, Birth, End);
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
