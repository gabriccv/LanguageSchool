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
    /// Interaction logic for WelcomeWindow.xaml
    /// </summary>
    public partial class WelcomeWindow : Window
    {
        public WelcomeWindow()
        {
            InitializeComponent();
        }
        private void btnProfessors_Click(object sender, RoutedEventArgs e)
        {
            var professorsWindow = new ShowProfessorsWindow();
            professorsWindow.ShowDialog();
            //this.Hide();
        }
        private void btnStudents_Click(object sender, RoutedEventArgs e)
        {
            var studentsWindow = new ShowStudentsWindow();
            studentsWindow.ShowDialog();
        }

        private void Address_Click(object sender, RoutedEventArgs e)
        {
            var addressWindow = new ShowAddressWindow();
            addressWindow.ShowDialog();
        }

        private void Class_Click(object sender, RoutedEventArgs e)
        {
            var classWindow = new ShowClassesWindow();
            classWindow.ShowDialog();
        }

        private void Language_Click(object sender, RoutedEventArgs e)
        {
            var languageWindow = new ShowLanguagesWindow();
            languageWindow.ShowDialog();
        }

        //private void Registration(object sender, RoutedEventArgs e)
        //{
        //    var registrationWindow = new Registration();
        //    registrationWindow.ShowDialog();

        //}

        //private void Login(object sender, RoutedEventArgs e)
        //{

        //}

        //private void Guest(object sender, RoutedEventArgs e)
        //{
        //    var mainWindow = new MainWindow();
        //    mainWindow.ShowDialog();
        //}
    }
}
