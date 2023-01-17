using SR39_2021_pop2022_2.Models;
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
    public partial class ShowSchoolWindow : Window
    {
        private SchoolService schoolService = new SchoolService();

        public ShowSchoolWindow()
        {
            InitializeComponent();
            RefreshDataGrid();
        }

        private void miAddSchool_Click(object sender, RoutedEventArgs e)
        {
            var addEditSchoolWindow = new AddEditSchoolWindow();

            var successeful = addEditSchoolWindow.ShowDialog();

            if ((bool)successeful)
            {
                RefreshDataGrid();
            }
        }

        private void miUpdateSchool_Click(object sender, RoutedEventArgs e)
        {
            var selectedIndex = dgSchools.SelectedIndex;

            if (selectedIndex >= 0)
            {
                var schools = schoolService.GetAll();

                var addEditSchoolWindow = new AddEditSchoolWindow(schools[selectedIndex]);

                var successeful = addEditSchoolWindow.ShowDialog();

                if ((bool)successeful)
                {
                    RefreshDataGrid();
                }
            }
        }

        private void miDeleteSchool_Click(object sender, RoutedEventArgs e)
        {
            var selectedSchool = dgSchools.SelectedItem as School;

            if (selectedSchool != null)
            {
                schoolService.Delete(selectedSchool.Id);
                RefreshDataGrid();
            }
        }

        private void RefreshDataGrid()
        {
            List<School> schools = schoolService.GetAll().Select(p => p).ToList();
            dgSchools.ItemsSource = schools;
        }

        private void dgSchools_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
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
                SchoolService schoolService = new SchoolService();
                List<School> filteredSchools = schoolService.GetValidSchool()
                    .Where(school => school.Name.ToLower().Contains(searchTerm.ToLower())
                                 || school.Language.ToString().Equals(searchTerm,StringComparison.OrdinalIgnoreCase)
                             || school.Address.ToString().Equals(searchTerm, StringComparison.OrdinalIgnoreCase))


                    .ToList();

                dgSchools.ItemsSource = filteredSchools;
            }

        }
    }
}
