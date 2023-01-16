using SR39_2021_pop2022_2.Models;
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
    public partial class AddEditStudentsWindow : Window
    {
        private Student student;
        private IStudentService studentService = new StudentService();
        private bool isAddMode;

        public AddEditStudentsWindow(Student student)
        {
            InitializeComponent();
            this.student = student.Clone() as Student;
            

            DataContext = this.student;
            tbAddress.DataContext = student;

            isAddMode = false;
            txtJMBG.IsReadOnly = true;
            txtEmail.IsReadOnly = true;
        }

        public AddEditStudentsWindow()
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
            tbAddress.DataContext = student;
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
        private void btnPickAddress_Click(object sender, RoutedEventArgs e)
        {
            ShowAddressWindow aw = new ShowAddressWindow(ShowAddressWindow.State.DOWNLOADING);
            if (aw.ShowDialog() == true)
            {
                student.User.Address = aw.SelectedAddress;

            }
        }
    }
    //public partial class AddEditStudentsWindow : Window
    //{
    //    private Student student;
    //    private IStudentService studentService = new StudentService();
    //    private bool isAddMode;

    //    public AddEditStudentsWindow(Student student)
    //    {
    //        InitializeComponent();
    //        this.student = student.Clone() as Student;

    //        DataContext = this.student;

    //        isAddMode = false;
    //        txtJMBG.IsReadOnly = true;
    //        txtEmail.IsReadOnly = true;
    //    }

    //    public AddEditStudentsWindow()
    //    {
    //        InitializeComponent();

    //        var user = new User
    //        {
    //            UserType = EUserType.STUDENT,
    //            IsActive = true
    //        };

    //        student = new Student
    //        {
    //            User = user
    //        };

    //        isAddMode = true;
    //        DataContext = student;
    //    }

    //    private void btnSave_Click(object sender, RoutedEventArgs e)
    //    {
    //        if (student.User.IsValid)
    //        {
    //            if (isAddMode)
    //            {
    //                studentService.Add(student);
    //            }
    //            else
    //            {
    //                studentService.Update(student.Id, student);
    //            }

    //            DialogResult = true;
    //            Close();
    //        }
    //    }

    //    private void btnCancel_Click(object sender, RoutedEventArgs e)
    //    {
    //        DialogResult = false;
    //        Close();
    //    }
    //}
}









