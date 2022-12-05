using SR39_2021_pop2022_2.Models;
using SR39_2021_POP2022_2.Models;
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

namespace SR39_2021_pop2022_2.Views
{
    /// <summary>
    /// Interaction logic for AddAddressWindow.xaml
    /// </summary>
    public partial class AddEditAddressWindow : Window
    {
        private Address newAddress;
        public AddEditAddressWindow()
        {
            InitializeComponent();
            newAddress = new Address();
            DataContext = newAddress;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Data.Instance.AddressService.Add(newAddress);
            this.DialogResult = true;
            this.Close();
        }
    }
}
