using SR39_2021_pop2022_2.Models;
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

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }
        private void Registration(object sender, RoutedEventArgs e)
        {
            var registrationWindow = new Registration();
            registrationWindow.ShowDialog();

        }

        private void Login(object sender, RoutedEventArgs e)
        {

        }

        private void Guest(object sender, RoutedEventArgs e)
        {
            var welcomeWindow = new WelcomeWindow();
            welcomeWindow.ShowDialog();
        }

        //private void btnProfessors_Click(object sender, RoutedEventArgs e)
        //{
        //    var professorsWindow = new ShowProfessorsWindow();
        //    professorsWindow.ShowDialog();
        //    //this.Hide();
        //}
        //private void btnStudents_Click(object sender, RoutedEventArgs e)
        //{
        //    var studentsWindow = new ShowStudentsWindow();
        //    studentsWindow.ShowDialog();
        //}

        //private void Address_Click(object sender, RoutedEventArgs e)
        //{
        //    var addressWindow = new ShowAddressWindow();
        //    addressWindow.ShowDialog();
        //}

        //private void Class_Click(object sender, RoutedEventArgs e)
        //{
        //    var classWindow = new ShowClassesWindow();
        //    classWindow.ShowDialog();
        //}
    }
}
