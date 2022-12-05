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
    /// Interaction logic for AllAddressesWindow.xaml
    /// </summary>
    public partial class ShowAddressWindow : Window
    {
        public ShowAddressWindow()
        {
            InitializeComponent();
            List<Address> addresses = Data.Instance.AddressService.GetAll().ToList();
            dgAddress.ItemsSource = addresses;
        }

        private void miAddAddress_Click(object sender, RoutedEventArgs e)
        {
            var addressWindow = new AddEditAddressWindow();
            var succesful = addressWindow.ShowDialog();
            if ((bool)succesful)
            {
                dgAddress.ItemsSource = Data.Instance.AddressService.GetAll().ToList();
            }
        }


        private void miDeleteAddress_Click(object sender, RoutedEventArgs e)
        {
            var selctedItem = ((Address)dgAddress.SelectedItem).Street;
            if (selctedItem != null)
            {
                MessageBoxResult ms = MessageBox.Show("Da li ste sigurni da zelite daobrisete adresu" + selctedItem, "", MessageBoxButton.YesNo);
                {
                    if (ms == MessageBoxResult.Yes)
                    {
                        Data.Instance.AddressService.Delete(selctedItem);
                        List<Address> addresses = Data.Instance.AddressService.GetAll().ToList();
                        dgAddress.ItemsSource = addresses;
                    }
                }
            }
        }
        private void dgAddress_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {

        }
    }

}
