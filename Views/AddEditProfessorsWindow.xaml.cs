using Microsoft.VisualBasic.ApplicationServices;
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
using User = SR39_2021_POP2022_2.Models.User;

namespace SR39_2021_pop2022_2.Views
{
    public partial class AddEditProfessorsWindow : Window
    {
        private Professor professor;
        private IProfessorService professorService = new ProfessorService();
        private bool isAddMode;



        public AddEditProfessorsWindow(Professor professor)
        {

            InitializeComponent();
            this.professor = professor.Clone() as Professor;

            DataContext = this.professor;
            tbAddress.DataContext = professor;

            isAddMode = false;
            txtJMBG.IsReadOnly = true;
            txtEmail.IsReadOnly = true;
        }

        public AddEditProfessorsWindow()
        {
            InitializeComponent();

            var user = new User
            {
                UserType = EUserType.PROFESSOR,
                IsActive = true,

            };

            professor = new Professor
            {
                User = user

            };

            isAddMode = true;
            DataContext = professor;
            tbAddress.DataContext = professor;

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (professor.User.IsValid)
            {
                if (isAddMode)
                {
                    professorService.Add(professor);
                }
                else
                {
                    professorService.Update(professor.Id, professor);
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
                professor.User.Address = aw.SelectedAddress;

            }
        }
    }
    //public partial class AddEditProfessorsWindow : Window
    //{

    //    private Professor professor;
    //    private IProfessorService professorService = new ProfessorService();
    //    private bool isAddMode;

    //    public AddEditProfessorsWindow(Professor professor)
    //    {
    //        InitializeComponent();
    //        this.professor = professor.Clone() as Professor;

    //        DataContext = this.professor;

    //        isAddMode = false;
    //        txtJMBG.IsReadOnly = true;
    //        txtEmail.IsReadOnly = true;
    //    }

    //    public AddEditProfessorsWindow()
    //    {
    //        InitializeComponent();

    //        var user = new User
    //        {
    //            UserType = EUserType.PROFESSOR,
    //            IsActive = true
    //        };

    //        professor = new Professor
    //        {
    //            User = user
    //        };

    //        isAddMode = true;
    //        DataContext = professor;
    //    }

    //    private void btnSave_Click(object sender, RoutedEventArgs e)
    //    {
    //        if (professor.User.IsValid)
    //        {
    //            if (isAddMode)
    //            {
    //                professorService.Add(professor);
    //            }
    //            else
    //            {
    //                professorService.Update(professor.Id, professor);
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