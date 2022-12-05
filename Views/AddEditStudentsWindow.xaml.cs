﻿using SR39_2021_pop2022_2.Models;
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
    /// Interaction logic for AddStudentWindow.xaml
    /// </summary>
    public partial class AddEditStudentsWindow : Window
    {
        private User newUser;
        public AddEditStudentsWindow()
        {
            InitializeComponent();
            newUser = new User
            {
                UserType = EUserType.STUDENT,
                IsActive = true

            };
            DataContext = newUser;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Data.Instance.StudentService.Add(newUser);
            this.DialogResult = true;
            this.Close();
        }
    }
}









