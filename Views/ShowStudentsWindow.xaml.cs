using SR39_2021_pop2022_2.Models;
using SR39_2021_pop2022_2.Services;
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



    public partial class ShowStudentsWindow : Window
    {
        private StudentService studentService = new StudentService();

        public enum State { ADMINISTRATION, DOWNLOADING };
        State state;
        public Student SelectedStudent = null;

        public ShowStudentsWindow(State state = State.ADMINISTRATION)
        {
            InitializeComponent();
            this.state = state;

            if (state == State.DOWNLOADING)
            {
                miAddStudent.Visibility = Visibility.Collapsed;
                miUpdateStudent.Visibility = Visibility.Collapsed;
                miDeleteStudent.Visibility = Visibility.Collapsed;
            }
            else
            {
                miPickStudent.Visibility = Visibility.Hidden;
            }

            //dgAddresses.ItemsSource = Data.Instance.Addresses;
            dgStudent.ItemsSource = studentService.GetAll();

            dgStudent.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
        }

        public ShowStudentsWindow()
        {
            InitializeComponent();
            RefreshDataGrid();
        }

        private void miAddStudent_Click(object sender, RoutedEventArgs e)
        {
            var addEditStudentWindow = new AddEditStudentsWindow();

            var successeful = addEditStudentWindow.ShowDialog();

            if ((bool)successeful)
            {
                RefreshDataGrid();
            }
        }
        private void miPickStudent_Click(object sender, RoutedEventArgs e)
        {
            SelectedStudent = dgStudent.SelectedItem as Student;
            this.DialogResult = true;
            this.Close();
        }

        private void miUpdateStudent_Click(object sender, RoutedEventArgs e)
        {
            var selectedIndex = dgStudent.SelectedIndex;

            if (selectedIndex >= 0)
            {
                var students = studentService.GetAll();

                var addEditStudentWindow = new AddEditStudentsWindow(students[selectedIndex]);

                var successeful = addEditStudentWindow.ShowDialog();

                if ((bool)successeful)
                {
                    RefreshDataGrid();
                }
            }
        }

        private void miDeleteStudent_Click(object sender, RoutedEventArgs e)
        {
            var selectedUser = dgStudent.SelectedItem as User;

            if (selectedUser != null)
            {
                studentService.Delete(selectedUser.Id);
                RefreshDataGrid();
            }
        }

        private void RefreshDataGrid()
        {
            List<User> users = studentService.GetAll().Select(p => p.User).ToList();
            dgStudent.ItemsSource = users;
        }

        private void dgStudents_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "Error" || e.PropertyName == "IsValid")
            {
                e.Column.Visibility = Visibility.Collapsed;
            }
        }
    }
}
