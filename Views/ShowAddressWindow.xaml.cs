﻿using SR39_2021_pop2022_2.Models;
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

    public partial class ShowAddressWindow : Window
    {
        private AddressService addressService = new AddressService();

        public ShowAddressWindow()
        {
            InitializeComponent();
            RefreshDataGrid();
        }

        private void miAddAddress_Click(object sender, RoutedEventArgs e)
        {
            var addEditAddressWindow = new AddEditAddressWindow();

            var successeful = addEditAddressWindow.ShowDialog();

            if ((bool)successeful)
            {
                RefreshDataGrid();
            }
        }

        private void miUpdateAddress_Click(object sender, RoutedEventArgs e)
        {
            var selectedIndex = dgAddress.SelectedIndex;

            if (selectedIndex >= 0)
            {
                var address = addressService.GetAll();

                var addEditAddressWindow = new AddEditAddressWindow(address[selectedIndex]);

                var successeful = addEditAddressWindow.ShowDialog();

                if ((bool)successeful)
                {
                    RefreshDataGrid();
                }
            }
        }

        private void miDeleteAddress_Click(object sender, RoutedEventArgs e)
        {
            var selectedAddress = dgAddress.SelectedItem as Address;

            if (selectedAddress != null)
            {
                addressService.Delete(selectedAddress.Id);
                RefreshDataGrid();
            }
        }

        private void RefreshDataGrid()
        {
            List<Address> addresses = addressService.GetAll().Select(p => p).ToList();
            dgAddress.ItemsSource = addresses;
        }

        private void dgAddress_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "Error" || e.PropertyName == "IsValid")
            {
                e.Column.Visibility = Visibility.Collapsed;
            }
        }
    }

}
