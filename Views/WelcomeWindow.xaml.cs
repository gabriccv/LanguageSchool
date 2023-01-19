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
    /// Interaction logic for WelcomeWindow.xaml
    /// </summary>
    public partial class WelcomeWindow : Window
    {

        
        private User _logUser;

        public WelcomeWindow(User _loggUser, EUserType _loggUserType)
        {
            InitializeComponent();
            _logUser = _loggUser;
            OpenWindows();
        }
        public WelcomeWindow()
        {
            InitializeComponent();
        }
        public void OpenWindows()
        {
            if (_logUser == null)
            {
                btnProfessors.IsEnabled = false;
                btnStudents.IsEnabled = false;
                btnAddress.IsEnabled = false;
                btnClass.IsEnabled = false;
                btnLanguage.IsEnabled = false;
                btnSchool.IsEnabled = false;
                //btnLogout.IsEnabled = false;
            }
            else
            {
                if (_logUser.UserType == EUserType.STUDENT)
                {
                    //btnProfessors.IsEnabled = false;
                    btnProfessors.Visibility = Visibility.Collapsed;
                    btnStudents.Visibility = Visibility.Collapsed;
                    btnClass.Visibility = Visibility.Collapsed;
                    btnSchool.Visibility = Visibility.Collapsed;
                    btnAddress.Visibility = Visibility.Collapsed;
                    btnLanguage.Visibility = Visibility.Collapsed;
                    btnPProfessor.Visibility = Visibility.Collapsed;

                }
                else if (_logUser.UserType == EUserType.PROFESSOR)
                {
                    btnProfessors.Visibility = Visibility.Collapsed;
                    btnStudents.Visibility = Visibility.Collapsed;
                    btnAddress.Visibility = Visibility.Collapsed;
                    btnSchool.Visibility = Visibility.Collapsed;
                    btnLanguage.Visibility = Visibility.Collapsed;
                    btnSProfessor.Visibility = Visibility.Collapsed;
                    btnSStudent.Visibility = Visibility.Collapsed;
                    btnSSchool.Visibility = Visibility.Collapsed;
                    btnSClass.Visibility = Visibility.Collapsed;
                }
                else if (_logUser.UserType == EUserType.ADMINISTRATOR)
                {
                    btnSProfessor.Visibility = Visibility.Collapsed;
                    btnSStudent.Visibility = Visibility.Collapsed;
                    btnSSchool.Visibility = Visibility.Collapsed;
                    btnSClass.Visibility = Visibility.Collapsed;
                    btnPProfessor.Visibility = Visibility.Collapsed;
                }
                btnLogout.IsEnabled = true;
            }
        }


            //public WelcomeWindow()
            //{
            //    InitializeComponent();
            //}
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

        private void School_Click(object sender, RoutedEventArgs e)
        {
            var schoolWindow = new ShowSchoolWindow();
            schoolWindow.ShowDialog();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.ShowDialog();
        }

        private void Sprofessor_Click(object sender, RoutedEventArgs e)
        {
            var profWindow = new StudentProfWindowxaml();
            profWindow.ShowDialog();
        }

        private void SStudent_Click(object sender, RoutedEventArgs e)
        {
            var SstudWindow = new StudentSWindow();
            SstudWindow.ShowDialog();

        }

        private void SSchool_Click(object sender, RoutedEventArgs e)
        {
            var SschoolWindow = new StudentSchoolWindow();
            SschoolWindow.ShowDialog();
        }

        private void SClass_Click(object sender, RoutedEventArgs e)
        {
            var SclassWindow = new StudentCWindow();
            SclassWindow.ShowDialog();
        }

        private void ProfessorP_Click(object sender, RoutedEventArgs e)
        {
            var professorP = new ProfessorPWindow();
            professorP.ShowDialog();
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
