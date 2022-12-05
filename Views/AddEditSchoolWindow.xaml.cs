﻿using SR39_2021_pop2022_2.Models;
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
    /// Interaction logic for AddSchoolWindow.xaml
    /// </summary>
    public partial class AddEditSchoolWindow : Window
    {
        private School newSchool;
        public AddEditSchoolWindow()
        {
            InitializeComponent();
            newSchool = new School();
            DataContext = newSchool;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Data.Instance.SchoolService.Add(newSchool);
            this.DialogResult = true;
            this.Close();
        }
    }
}