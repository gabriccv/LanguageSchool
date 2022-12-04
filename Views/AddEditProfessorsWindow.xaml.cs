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
    public partial class AddEditProfessorsWindow : Window
    {
        private User newUser;
        private Professor professor;
        private IProfessorService professorService = new ProfessorService();
        private bool isAddMode;

        public AddEditProfessorsWindow(User user)
        {
            InitializeComponent();
            this.newUser = user.Clone() as User;

            DataContext = this.newUser;

            isAddMode = false;
            txtJMBG.IsReadOnly = true;
            txtEmail.IsReadOnly = true;

        }

        public AddEditProfessorsWindow()
        {
            InitializeComponent();

            newUser = new User
            {
                UserType = EUserType.PROFESSOR,
                IsActive = true
            };

            //professor = new Professor
            //{
            //    User = user
            //};

            isAddMode = true;
            DataContext = newUser;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
         
                Data.Instance.ProfessorService.Add(newUser);
    

            DialogResult = true;
            Close();
        }
    }
}
