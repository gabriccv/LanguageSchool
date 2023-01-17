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

    public partial class ShowProfessorsWindow : Window
    {
        private ProfessorService professorService = new ProfessorService();

        public enum State { ADMINISTRATION, DOWNLOADING };
        State state;
        public Professor SelectedProfessor = null;

        public ShowProfessorsWindow(State state = State.ADMINISTRATION)
        {
            InitializeComponent();
            this.state = state;

            if (state == State.DOWNLOADING)
            {
                miAddProfessor.Visibility = Visibility.Collapsed;
                miUpdateProfessor.Visibility = Visibility.Collapsed;
                miDeleteProfessor.Visibility = Visibility.Collapsed;
            }
            else
            {
                miPickProfessor.Visibility = Visibility.Hidden;
            }

            //dgAddresses.ItemsSource = Data.Instance.Addresses;
            dgProfessors.ItemsSource = professorService.GetAll();

            dgProfessors.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
        }

        private void miAddProfessor_Click(object sender, RoutedEventArgs e)
        {
            var addEditProfessorWindow = new AddEditProfessorsWindow();

            var successeful = addEditProfessorWindow.ShowDialog();

            if ((bool)successeful)
            {
                RefreshDataGrid();
            }
        }
        public ShowProfessorsWindow()
        {
            InitializeComponent();
            RefreshDataGrid();
        }

        private void miPickProfessor_Click(object sender, RoutedEventArgs e)
        {
            SelectedProfessor = dgProfessors.SelectedItem as Professor;
            this.DialogResult = true;
            this.Close();
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

        private void miDeleteProfessor_Click(object sender, RoutedEventArgs e)
        {
            var selectedUser = dgProfessors.SelectedItem as User;

            if (selectedUser != null)
            {
                professorService.Delete(selectedUser.Id);
                RefreshDataGrid();
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
    }
    //public partial class ShowProfessorsWindow : Window
    //{
    //    private ProfessorService professorService = new ProfessorService();

    //    public ShowProfessorsWindow()
    //    {
    //        InitializeComponent();
    //        RefreshDataGrid();
    //    }

    //    private void miAddProfessor_Click(object sender, RoutedEventArgs e)
    //    {
    //        var addEditProfessorWindow = new AddEditProfessorsWindow();

    //        var successeful = addEditProfessorWindow.ShowDialog();

    //        if ((bool)successeful)
    //        {
    //            RefreshDataGrid();
    //        }
    //    }

    //    private void miUpdateProfessor_Click(object sender, RoutedEventArgs e)
    //    {
    //        var selectedIndex = dgProfessors.SelectedIndex;

    //        if (selectedIndex >= 0)
    //        {
    //            var professors = professorService.GetAll();

    //            var addEditProfessorWindow = new AddEditProfessorsWindow(professors[selectedIndex]);

    //            var successeful = addEditProfessorWindow.ShowDialog();

    //            if ((bool)successeful)
    //            {
    //                RefreshDataGrid();
    //            }
    //        }
    //    }

    //    private void miDeleteProfessor_Click(object sender, RoutedEventArgs e)
    //    {
    //        var selectedUser = dgProfessors.SelectedItem as User;

    //        if (selectedUser != null)
    //        {
    //            professorService.Delete(selectedUser.Id);
    //            RefreshDataGrid();
    //        }

    //    }

    //    private void RefreshDataGrid()
    //    {
    //        List<User> users = professorService.GetAll().Select(p => p.User).ToList();
    //        dgProfessors.ItemsSource = users;
    //    }

    //    private void dgProfessors_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
    //    {
    //        if (e.PropertyName == "Error" || e.PropertyName == "IsValid")
    //        {
    //            e.Column.Visibility = Visibility.Collapsed;
    //        }

    //    }
    //}
}
