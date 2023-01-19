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
    /// <summary>
    /// Interaction logic for StudentSWindow.xaml
    /// </summary>
    public partial class StudentSWindow : Window
    {
        private StudentService studentService = new StudentService();

        
        public StudentSWindow()
        {
            InitializeComponent();
            RefreshDataGrid();
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
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                string searchTerm = txtSearch.Text;
                StudentService studService = new StudentService();
                List<Student> filteredStudents = studService.GetActiveStudents()
                    .Where(prof => prof.User.FirstName.ToLower().Contains(searchTerm.ToLower())
                                 || prof.User.LastName.ToLower().Contains(searchTerm.ToLower())
                                 || prof.User.Email.ToLower().Contains(searchTerm.ToLower())
                             || prof.User.Address.ToString().Equals(searchTerm, StringComparison.OrdinalIgnoreCase))


                    .ToList();

                dgStudent.ItemsSource = filteredStudents;
            }

        }
    }
}

