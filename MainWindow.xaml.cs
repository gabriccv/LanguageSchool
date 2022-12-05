﻿using SR39_2021_pop2022_2.Models;
using SR39_2021_pop2022_2.Views;
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

namespace SR39_2021_pop2022_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Data.Instance.LoadData();
        }

        private void btnStudent_Click(object sender, RoutedEventArgs e)
        {
            var studentsWindow = new ShowStudentsWindow();
            studentsWindow.Show();
            //Close();
        }

        private void btnProfessor_Click(object sender, RoutedEventArgs e)
        {
            var professorsWindow = new ShowProfessorsWindow();
            professorsWindow.Show();
            //Close();
        }

        private void btnAddress_Click(object sender, RoutedEventArgs e)
        {
            var addressWindow = new ShowAddressWindow();
            addressWindow.Show();
            //Close();
        }

        private void btnSchool_Click(object sender, RoutedEventArgs e)
        {
            var schoolWindow = new ShowSchoolsWindow();
            schoolWindow.Show();
            //Close();
        }

        private void btnClass_Click(object sender, RoutedEventArgs e)
        {
            var classWindow = new ShowClassesWindow();
            classWindow.Show();
            //Close();
        }
    }
}
