using SR39_2021_pop2022_2.Models;
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
    /// Interaction logic for AllSchoolsWindow.xaml
    /// </summary>
    public partial class ShowSchoolsWindow : Window
    {
        public ShowSchoolsWindow()
        {
            InitializeComponent();
            List<School> listSchools = Data.Instance.SchoolService.GetAll().ToList();
            dgSchools.ItemsSource = listSchools;
        }

        private void miAddSchool_Click(object sender, RoutedEventArgs e)
        {
            var schoolWindow = new AddEditSchoolWindow();
            var successful = schoolWindow.ShowDialog();

            if ((bool)successful)
            {
                dgSchools.ItemsSource = Data.Instance.SchoolService.GetAll().ToList();
            }
        }

        private void miDeleteSchool_Click(object sender, RoutedEventArgs e)
        {
            var selctedItem = ((School)dgSchools.SelectedItem).Name;
            if (selctedItem != null)
            {
                MessageBoxResult ms = MessageBox.Show("Da li ste sigurni da zelite daobrisete školu", "", MessageBoxButton.YesNo);
                {
                    if (ms == MessageBoxResult.Yes)
                    {
                        Data.Instance.SchoolService.Delete(selctedItem);
                        List<School> schools = Data.Instance.SchoolService.GetAll().ToList();
                        dgSchools.ItemsSource = schools;
                    }
                }
            }
        }
        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void dgSchools_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


    }
}
