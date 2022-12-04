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
    /// Interaction logic for ShowProfessorsWindow.xaml
    /// </summary>
    public partial class ShowProfessorsWindow : Window
    {
        private ProfessorService professorService = new ProfessorService();

        public ShowProfessorsWindow()
        {
            InitializeComponent();
            List<User> users = Data.Instance.ProfessorService.GetActiveProfessors()
                .Select(p => p.User).ToList();
            dgProfessors.ItemsSource = users;
        }

        private void miAddProfessor_Click(object sender, RoutedEventArgs e)
        {
            var addEditProfessorWindow = new AddEditProfessorsWindow();

            var successeful = addEditProfessorWindow.ShowDialog();

            if ((bool)successeful)
            {
                List<User> users = Data.Instance.ProfessorService.GetActiveProfessors()
                .Select(p => p.User).ToList();
                dgProfessors.ItemsSource = users;
            }
        }

        private void miUpdateProfessor_Click(object sender, RoutedEventArgs e)
        {
            var selectedIndex = dgProfessors.SelectedIndex;

            if (selectedIndex >= 0)
            {
                var professors = professorService.GetAll().Select(p=>p.User).ToList();

                var addEditProfessorWindow = new AddEditProfessorsWindow(professors[selectedIndex]);

                var successeful = addEditProfessorWindow.ShowDialog();

                if ((bool)successeful)
                {
                    RefreshDataGrid();
                }
            }
        }
        private void miDeleteProfessor_Click(object sender, RoutedEventArgs e)
        {
            var selctedItem = ((User)dgProfessors.SelectedItem).Email;
            if (selctedItem != null)
            {
                MessageBoxResult ms = MessageBox.Show("Da li ste sigurni da zelite da obrisete profesor", "", MessageBoxButton.YesNo);
                {
                    if (ms == MessageBoxResult.Yes)
                    {
                        Data.Instance.ProfessorService.Delete(selctedItem);
                        List<User> users = Data.Instance.ProfessorService.GetActiveProfessors().Select(p => p.User).ToList();
                        dgProfessors.ItemsSource = users;
                    }
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


        //private void txtSearch_KeyDown
    }
}
