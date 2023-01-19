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
    /// Interaction logic for StudentCWindow.xaml
    /// </summary>
    public partial class StudentCWindow : Window
    {
        private ClassService classService = new ClassService();

        public StudentCWindow()
        {
            InitializeComponent();
            RefreshDataGrid();
        }


        private void miUpdateClass_Click(object sender, RoutedEventArgs e)
        {
            var selectedIndex = dgClasses.SelectedIndex;

            if (selectedIndex >= 0)
            {
                var classes = classService.GetAll();

                var addEditClassWindow = new AddEditClassWindow(classes[selectedIndex]);

                var successeful = addEditClassWindow.ShowDialog();

                if ((bool)successeful)
                {
                    RefreshDataGrid();
                }
            }
        }


        private void RefreshDataGrid()
        {
            List<Class> classes = classService.GetAll().Select(p => p).ToList();
            dgClasses.ItemsSource = classes;
        }

        private void dgClasses_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "Error" || e.PropertyName == "IsValid")
            {
                e.Column.Visibility = Visibility.Collapsed;
            }
        }
    }
}
