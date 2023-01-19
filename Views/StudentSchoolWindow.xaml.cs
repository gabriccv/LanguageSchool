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
    /// <summary>
    /// Interaction logic for StudentSchoolWindow.xaml
    /// </summary>
    public partial class StudentSchoolWindow : Window
    {
        private SchoolService schoolService = new SchoolService();

        public StudentSchoolWindow()
        {
            InitializeComponent();
            RefreshDataGrid();


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
                                 || school.Language.ToString().Equals(searchTerm, StringComparison.OrdinalIgnoreCase)
                             || school.Address.ToString().Equals(searchTerm, StringComparison.OrdinalIgnoreCase))


                    .ToList();

                dgSchools.ItemsSource = filteredSchools;
            }

        }
    }
}
