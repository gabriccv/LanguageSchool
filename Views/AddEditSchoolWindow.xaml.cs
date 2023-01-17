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
    public partial class AddEditSchoolWindow : Window
    {
        private School school;
        private ISchoolService schoolService = new SchoolService();
        private bool isAddMode;

        public AddEditSchoolWindow(School school)
        {
            InitializeComponent();
            this.school = school.Clone() as School;

            DataContext = this.school;
            isAddMode = false;

        }

        public AddEditSchoolWindow()
        {
            InitializeComponent();

            school = new School
            {

                IsDeleted = false
            };



            isAddMode = true;
            DataContext = school;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            //if (school.IsValid)
            //{
                if (isAddMode)
                {
                    schoolService.Add(school);
                }
                else
                {
                    schoolService.Update(school.Id, school);
                }

                DialogResult = true;
                Close();
            //}
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void btnPickAddress_Click(object sender, RoutedEventArgs e)
        {
            ShowAddressWindow aw = new ShowAddressWindow(ShowAddressWindow.State.DOWNLOADING);
            if (aw.ShowDialog() == true)
            {
                school.Address = aw.SelectedAddress;

            }
        }
        private void btnPickLanguage_Click(object sender, RoutedEventArgs e)
        {
            ShowLanguagesWindow aw = new ShowLanguagesWindow(ShowLanguagesWindow.State.DOWNLOADING);
            if (aw.ShowDialog() == true)
            {
                school.Language = aw.SelectedLanguage;

            }
        }
    }
}
