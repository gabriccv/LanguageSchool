using SR39_2021_pop2022_2.Models;
using SR39_2021_POP2022_2.Models;
using SR39_2021_pop2022_2.Services;
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
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        private Student student;
        private IStudentService studentService = new StudentService();
        private bool isAddMode;


        public Registration()
        {
            InitializeComponent();

            var user = new User
            {
                UserType = EUserType.STUDENT,
                IsActive = true
            };

            student = new Student
            {
                User = user
            };

            isAddMode = true;
            DataContext = student;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (student.User.IsValid)
            {
                if (isAddMode)
                {
                    studentService.Add(student);
                }
                else
                {
                    studentService.Update(student.Id, student);
                }

                DialogResult = true;
                Close();
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}

