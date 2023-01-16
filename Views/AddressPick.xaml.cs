using SR39_2021_pop2022_2.Models;
using SR39_2021_pop2022_2.Services;
using SR39_2021_POP2022_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
    public partial class AddressPick : Window
    {
        public enum Stanje { ADMINISTRACIJA, PREUZIMANJE };
        Stanje stanje;
        private AddressService addressService;

        public Address SelectedAddress = null;

        public AddressPick(Stanje stanje = Stanje.ADMINISTRACIJA)
        {
            InitializeComponent();
            this.stanje = stanje;

            if (stanje == Stanje.PREUZIMANJE)
            {
                btnAdd.Visibility = Visibility.Collapsed;
                btnDelete.Visibility = Visibility.Collapsed;
                btnUpdate.Visibility = Visibility.Collapsed;
                //RefreshDataGrid();
            }
            else
            {
                btnPick.Visibility = Visibility.Hidden;
            }

            dgAddresses.ItemsSource = Aplication.Instance.Addresses;

            dgAddresses.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
        }

        

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnPick_Click(object sender, RoutedEventArgs e)
        {
            SelectedAddress = dgAddresses.SelectedItem as Address;
            this.DialogResult = true;
            this.Close();
        }
        //private void RefreshDataGrid()
        //{
        //    List<Address> addresses = addressService.GetAll().Select(p => p).ToList();
        //    dgAddresses.ItemsSource = addresses;
        //}
    }
}
