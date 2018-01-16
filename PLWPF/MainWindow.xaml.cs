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

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
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
    }
}
