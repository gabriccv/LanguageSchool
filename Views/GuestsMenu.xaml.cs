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
    /// Interaction logic for GuestsMenu.xaml
    /// </summary>
    public partial class GuestsMenu : Window
    {
        public GuestsMenu()
        {
            InitializeComponent();
        }

        private void btnProfessors_Click(object sender, RoutedEventArgs e)
        {
            var professorsWindow = new ShowProfessorsWindow();
            professorsWindow.ShowDialog();
            //this.Hide();
        }

        private void btnSchools_Click(object sender, RoutedEventArgs e)
        {
            var schoolWindow = new ShowSchoolWindow();
            schoolWindow.ShowDialog();
        }
    }
}
