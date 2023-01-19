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
    /// Interaction logic for ProfessorPWindow.xaml
    /// </summary>
    public partial class ProfessorPWindow : Window
    {
        private ProfessorService professorService = new ProfessorService();

        
        public ProfessorPWindow()
        {
            InitializeComponent();
            RefreshDataGrid();
        }

       

        private void miUpdateProfessor_Click(object sender, RoutedEventArgs e)
        {
            var selectedIndex = dgProfessors.SelectedIndex;

            if (selectedIndex >= 0)
            {
                var professors = professorService.GetAll();

                var addEditProfessorWindow = new AddEditProfessorsWindow(professors[selectedIndex]);

                var successeful = addEditProfessorWindow.ShowDialog();

                if ((bool)successeful)
                {
                    RefreshDataGrid();
                }
            }
        }
        private void RefreshDataGrid()
        {
            List<User> users = professorService.GetAll().Select(p => p.User).ToList();
            dgProfessors.ItemsSource = users;
        }

        private void dgProfessors_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
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
                ProfessorService profService = new ProfessorService();
                List<Professor> filteredProfesors = profService.GetActiveProfessors()
                    .Where(prof => prof.User.FirstName.ToLower().Contains(searchTerm.ToLower())
                                 || prof.User.LastName.ToLower().Contains(searchTerm.ToLower())
                                 || prof.User.Email.ToLower().Contains(searchTerm.ToLower())
                             || prof.User.Address.ToString().Equals(searchTerm, StringComparison.OrdinalIgnoreCase))


                    .ToList();

                dgProfessors.ItemsSource = filteredProfesors;
            }

        }
    }
}
