using SR39_2021_pop2022_2.Models;
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
    /// Interaction logic for AllStudentsWindow.xaml
    /// </summary>
    public partial class ShowStudentsWindow : Window
    {
        public ShowStudentsWindow()
        {
            InitializeComponent();
            List<User> users = Data.Instance.StudentService.GetAll().Select(p => p.User).ToList();
            dgStudent.ItemsSource = users;

        }

        private void miAddStudent_Click(object sender, RoutedEventArgs e)
        {
            var studetWindow = new AddEditStudentsWindow();
            var successful = studetWindow.ShowDialog();

            if ((bool)successful)
            {
                dgStudent.ItemsSource = Data.Instance.StudentService.GetAll().Select(p => p.User).ToList();
            }
        }

        private void miDeleteStudent_Click(object sender, RoutedEventArgs e)
        {
            var selctedItem = ((User)dgStudent.SelectedItem).Email;
            if (selctedItem != null)
            {
                MessageBoxResult ms = MessageBox.Show("Da li ste sigurni da zelite daobrisete studenta", "", MessageBoxButton.YesNo);
                {
                    if (ms == MessageBoxResult.Yes)
                    {
                        Data.Instance.StudentService.Delete(selctedItem);
                        List<User> users = Data.Instance.StudentService.GetAll().Select(p => p.User).ToList();
                        dgStudent.ItemsSource = users;
                    }
                }
            }

        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void dgStudent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var value = txtSearch.Text;
            Data.Instance.StudentService.Search(value);
        }
    }
}
