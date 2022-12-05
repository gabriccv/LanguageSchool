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
    /// Interaction logic for AllClassesWindow.xaml
    /// </summary>
    public partial class ShowClassesWindow : Window
    {
        public ShowClassesWindow()
        {
            InitializeComponent();
            List<Class> classes = Data.Instance.ClassService.GetAll().ToList();
            dgClasses.ItemsSource = classes;
        }

        private void miAddClasses_Click(object sender, RoutedEventArgs e)
        {
            var classWindow = new AddEditClassWindow();
            var succesful = classWindow.ShowDialog();
            if ((bool)succesful)
            {
                List<Class> classes = Data.Instance.ClassService.GetAll().ToList();
                dgClasses.ItemsSource = classes;
            }
        }

        private void miDeleteClasses_Click(object sender, RoutedEventArgs e)
        {
            var selctedItem = ((Class)dgClasses.SelectedItem).Name;
            if (selctedItem != null)
            {
                MessageBoxResult ms = MessageBox.Show("Da li ste sigurni da zelite daobrisete cas" + selctedItem, "", MessageBoxButton.YesNo);
                {
                    if (ms == MessageBoxResult.Yes)
                    {
                        Data.Instance.ClassService.Delete(selctedItem);
                        List<Class> addresses = Data.Instance.ClassService.GetAll().ToList();
                        dgClasses.ItemsSource = addresses;
                    }
                }
            }
        }



        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void dgClasses_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
